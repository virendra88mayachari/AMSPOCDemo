using AMSServicesPOC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AMSServicesPOC.Utility
{
    public class DIALSUtility
    {
        public static DIALS ProcessDIALSData(string dialsString)
        {
            DIALS dialsData = new DIALS();
            dialsData.TrackingNumber = dialsString.Substring(0, 18).Trim();
            dialsData.ShiperNumber = dialsString.Length > 348 ? dialsString.Substring(348, 10).Trim() : "";
            dialsData.ClarifiedSignature = dialsString.Length > 295 ? dialsString.Substring(295, 15).Trim() : "";
            dialsData.ConsigneeName = dialsString.Length > 270 ? dialsString.Substring(270, 25).Trim() : "";
            dialsData.Region = dialsString.Length > 120 ? dialsString.Substring(120, 2).Trim() : "";
            dialsData.District = dialsString.Length > 122 ? dialsString.Substring(122, 2).Trim() : "";
            dialsData.SLIC = dialsString.Length > 124 ? dialsString.Substring(124, 5).Trim() : "";
            dialsData.Country = dialsString.Length > 129 ? dialsString.Substring(129, 2).Trim() : "";
            dialsData.DeliverySLICState = dialsString.Length > 131 ? dialsString.Substring(131, 2).Trim() : "";
            dialsData.City = dialsString.Length > 139 ? dialsString.Substring(139, 30).Trim() : "";
            dialsData.StreetNumber = dialsString.Length > 169 ? dialsString.Substring(169, 11).Trim() : "";
            dialsData.StreetName = dialsString.Length > 182 ? dialsString.Substring(182, 30).Trim() : "";
            dialsData.StreetType = dialsString.Length > 212 ? dialsString.Substring(212, 4).Trim() : "";
            dialsData.BuildingFloorNumber = dialsString.Length > 218 ? dialsString.Substring(218, 3).Trim() : "";
            dialsData.RoomSuiteNumber = dialsString.Length > 221 ? dialsString.Substring(221, 8).Trim() : "";
            dialsData.PostalCode = dialsString.Length > 229 ? dialsString.Substring(229, 8).Trim() : "";

            return dialsData;
        }
    }
}
