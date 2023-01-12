using Markel.Claims.Service.Data.JsonConverters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Text.Json.Serialization;

namespace Markel.Claims.Service.Data
{
    public class Company
    {
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Address3 { get; set; }
        public string PostCode { get; set; }
        public string Country { get; set; }
        [JsonConverter(typeof(MarkelBooleanConverter))]
        public bool IsActive { get; set; }
        public DateTime InsuranceEndDate { get; set; }

        public bool HasActivePolicy { get; set; }
    }
}
