using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AMSServicesPOC.Models
{
    public class OPLD
    {
        public int OPLDID { get; set; }
        public string TrackingNumber { get; set; }
        public string ShiperNumber { get; set; }
        public string ShiperCountry { get; set; }
        public string VersionNumber { get; set; }
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
        public string CreatedDate { get; set; }
    }
}

