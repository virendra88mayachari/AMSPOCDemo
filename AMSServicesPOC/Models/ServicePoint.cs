using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AMSServicesPOC.Models
{
    public class ServicePoint
    {
        public int ServicePointID { get; set; }
        public string ShiperNumber { get; set; }
        public string ConsigneeName { get; set; }
        public string AttentionName { get; set; }
        public string AddressType { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string AddressLine3 { get; set; }
        public string CityName { get; set; }
        public string StateCode { get; set; }
        public string ZipCode { get; set; }
        public string CountryCode { get; set; }
        public string PhoneNumber { get; set; }
        public string SignatureClarify { get; set; }
        public string CreatedDate { get; set; }

        public string ServicePointStatus { get; set; }
    }
}
