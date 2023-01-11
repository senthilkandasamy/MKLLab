using Markel.Claims.Service.Data.JsonConverters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.Json.Serialization;

namespace Markel.Claims.Service.Data
{
    public class Claims
    {
        public int ClaimId { get; set;}
        [Required]
        [StringLength(10)]
        public string UCR { get; set; }
        [Required]
        public int CompanyId { get; set; }
        [Required]
        public DateTime ClaimDate { get; set; }
        [Required]
        public DateTime LossDate { get; set; }
        [Required]
        public string AssuredName { get; set; }
        [Required]
        public decimal IncurredLoss { get; set; }
        [Required]
        [JsonConverter(typeof(MarkelBooleanConverter))]
        public bool Closed { get; set; }

        public int NumberOfDaysOld { get; set; }
    }
}
    