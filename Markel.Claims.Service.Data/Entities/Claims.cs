using Markel.Claims.Service.Data.JsonConverters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Text.Json.Serialization;

namespace Markel.Claims.Service.Data
{
    public class Claims
    {
        public int ClaimId { get; set;}
        public string UCR { get; set; }
        public int CompanyId { get; set; }
        public DateTime ClaimDate { get; set; }
        public DateTime LossDate { get; set; }
        public string AssuredName { get; set; }
        public decimal IncurredLoss { get; set; }
        [JsonConverter(typeof(MarkelBooleanConverter))]
        public bool Closed { get; set; }
        public int NumberOfDaysOld { get; set; }
    }
}
    