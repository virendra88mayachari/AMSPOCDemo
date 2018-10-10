using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AMSServicesPOC.Models
{
    public class DIALS
    {
        public int DialsID { get; set; }
        public string TrackingNumber { get; set; }
        public string ShiperNumber { get; set; }
        public string ClarifiedSignature { get; set; }
        public string ConsigneeName { get; set; }
        public string Region { get; set; }
        public string District { get; set; }
        public string SLIC { get; set; }
        public string Country { get; set; }
        public string DeliverySLICState { get; set; }
        public string City { get; set; }
        public string StreetNumber { get; set; }
        public string StreetName { get; set; }
        public string StreetType { get; set; }
        public string BuildingFloorNumber { get; set; }
        public string RoomSuiteNumber { get; set; }
        public string PostalCode { get; set; }
    }
}
