using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobinHoodDownload.API.Robin.DataModel
{
    public class InstantEligibility
    {
        [JsonProperty("reason")]
        public string Reason { get; set; }

        [JsonProperty("reinstatement_date")]
        public object ReinstatementDate { get; set; }

        [JsonProperty("reversal")]
        public object Reversal { get; set; }

        [JsonProperty("state")]
        public string State { get; set; }

        [JsonProperty("updated_at")]
        public object UpdatedAt { get; set; }

        [JsonProperty("additional_deposit_needed")]
        public string AdditionalDepositNeeded { get; set; }

        [JsonProperty("compliance_user_major_oak_email")]
        public object ComplianceUserMajorOakEmail { get; set; }

        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("created_by")]
        public object CreatedBy { get; set; }
    }

}
