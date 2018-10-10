using AMSServicesPOC.DatabaseOps;
using AMSServicesPOC.Models;
using AMSServicesPOC.Utility;
using Microsoft.AspNetCore.Mvc;
using System;

namespace AMSServicesPOC.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ServicePointController : ControllerBase
    {
        private static readonly log4net.ILog log =
            log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        //MicroService 4
        public IActionResult ReadMQ2OPLDNCreateSPNPushTOMQ3()
        {
            try
            {
                //Read from MQ
                OPLD opldObject = CommonUtility<OPLD>.PullFromActiveMQ(2);

                log.Info(DateTime.Now.ToString() + " AMS-POC: Service point genration process started.");

                ServicePoint servicePointObject = new ServicePoint();

                //CreateServicepoint          
                //Check if opld tracking number matches with dials matching number
                SakilaContext context = HttpContext.RequestServices.GetService(typeof(SakilaContext)) as SakilaContext;
                DIALS dialsObject = context.GetMatchingDialsID(opldObject.TrackingNumber);
                
                if (dialsObject != null)
                {
                    servicePointObject = ServicePointUtility.CreateServicePoint(opldObject, dialsObject.ConsigneeName, dialsObject.ClarifiedSignature, true);
                }
                else
                {
                    servicePointObject = ServicePointUtility.CreateServicePoint(opldObject, "", "", false);
                }

                //Push OPLD in to Active MQ2
                CommonUtility<ServicePoint>.PushToActiveMQ(servicePointObject, 3);

                log.Info(DateTime.Now.ToString() + " AMS-POC: Service point Created and Pushed to MQ3.");
            }
            catch(Exception ex)
            {
                log.Error(DateTime.Now.ToString() + " AMS-POC: " + Convert.ToString(ex.Message));
                return new JsonResult(new { Result = System.Net.HttpStatusCode.InternalServerError });
            }

            return Ok();
        }

        //MicroService 5
        public IActionResult ReadMQ3ServicePointNWriteToDB()
        {
            try
            {
                //Read from MQ
                ServicePoint servicePointObject = CommonUtility<ServicePoint>.PullFromActiveMQ(3);

                //Write Servicepoint to DB
                SakilaContext context = HttpContext.RequestServices.GetService(typeof(SakilaContext)) as SakilaContext;
                context.AddNewServicePoint(servicePointObject);

                log.Info(DateTime.Now.ToString() + " AMS-POC: Service point inserted in to database.");
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