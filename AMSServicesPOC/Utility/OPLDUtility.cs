using AMSServicesPOC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AMSServicesPOC.Utility
{
    public class OPLDUtility
    {
        public static OPLD ProcessOPLD(string opldString)
        {
            OPLD opldData = new OPLD();
            opldData.TrackingNumber = opldString.Length > 3533 ? opldString.Substring(3533, 35).Trim() : "";
            opldData.VersionNumber = opldString.Length > 2 ? opldString.Substring(2, 4).Trim() : "";
            opldData.ShiperNumber = opldString.Length > 55 ? opldString.Substring(55, 10).Trim() : "";
            opldData.ShiperCountry = opldString.Length > 65 ? opldString.Substring(65, 2).Trim() : "";
            opldData.AttentionName = opldString.Length > 229 ? opldString.Substring(229, 35).Trim() : "";
            opldData.AddressType = opldString.Length > 182 ? opldString.Substring(182, 2).Trim() : "";
            opldData.AddressLine1 = opldString.Length > 264 ? opldString.Substring(264, 35).Trim() : "";
            opldData.AddressLine2 = opldString.Length > 299 ? opldString.Substring(299, 35).Trim() : "";
            opldData.AddressLine3 = opldString.Length > 334 ? opldString.Substring(334, 35).Trim() : "";
            opldData.CityName = opldString.Length > 369 ? opldString.Substring(369, 30).Trim() : "";
            opldData.StateCode = opldString.Length > 399 ? opldString.Substring(399, 5).Trim() : "";
            opldData.ZipCode = opldString.Length > 404 ? opldString.Substring(404, 9).Trim() : "";
            opldData.CountryCode = opldString.Length > 413 ? opldString.Substring(413, 2).Trim() : "";
            opldData.PhoneNumber = opldString.Length > 415 ? opldString.Substring(415, 15).Trim() : "";

            return opldData;
        }
    }
}
