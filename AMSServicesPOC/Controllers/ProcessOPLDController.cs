using Microsoft.AspNetCore.Mvc;
using System.IO;
using AMSServicesPOC.Models;
using AMSServicesPOC.Utility;
using AMSServicesPOC.DatabaseOps;
using System.Threading;
using System;

namespace AMSServicesPOC.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProcessOPLDController : ControllerBase
    {
        private static readonly log4net.ILog log =
            log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);


        //MicroService 1
        //[HttpPost]
        public IActionResult ProcessOPLDNPushTOMQ1()
        {
            try
            {
                string opldFolderPath = Path.Combine(Directory.GetCurrentDirectory(), "OPLDFiles");

                if (Directory.Exists(opldFolderPath))
                {
                    var files = Directory.GetFiles(opldFolderPath);

                    if (files.Length > 0)
                    {
                        foreach (string fileName in files)
                        {
                            log.Info(DateTime.Now.ToString() + " AMS-POC: OPLD file processing in progress.");
                            string opldString = System.IO.File.ReadAllText(Path.Combine(opldFolderPath, fileName));

                            //Process OPLD data
                            var opldObject = OPLDUtility.ProcessOPLD(opldString);

                            log.Info(DateTime.Now.ToString() + " AMS-POC: OPLD file processing completed.");

                            //Push OPLD in to Active MQ1
                            if (!string.IsNullOrEmpty(opldObject.TrackingNumber))
                            {
                                CommonUtility<OPLD>.PushToActiveMQ(opldObject, 1);

                                log.Info(DateTime.Now.ToString() + " AMS-POC: OPLD message pushed to MQ1.");
                            }
                            else {
                                log.Warn(DateTime.Now.ToString() + " AMS-POC: Tracking number not found in OPLD message.");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                log.Error(DateTime.Now.ToString() + " AMS-POC: " + Convert.ToString(ex.Message));
                return new JsonResult(new { Result = System.Net.HttpStatusCode.InternalServerError });
            }

            return Ok();
        }

        //MicroService 2
        public IActionResult ProcessMQ1OPLDMessageNWriteToDBNMQ2()
        {
            try
            {
                //Read from MQ
                OPLD opldObject = CommonUtility<OPLD>.PullFromActiveMQ(1);

                log.Info(DateTime.Now.ToString() + " AMS-POC: OPLD message read from MQ1.");

                //Store in to DB
                SakilaContext context = HttpContext.RequestServices.GetService(typeof(SakilaContext)) as SakilaContext;
                context.AddNewOPLD(opldObject);

                log.Info(DateTime.Now.ToString() + " AMS-POC: OPLD message inserted in to database.");

                //Push OPLD in to Active MQ2
                CommonUtility<OPLD>.PushToActiveMQ(opldObject, 2);
                log.Info(DateTime.Now.ToString() + " AMS-POC: OPLD message pushed to MQ2.");
            }
            catch (Exception ex)
            {
                log.Error(DateTime.Now.ToString() + " AMS-POC: " + Convert.ToString(ex.Message));
                return new JsonResult(new { Result = System.Net.HttpStatusCode.InternalServerError });
            }
            
            return Ok();
        }
    }
}