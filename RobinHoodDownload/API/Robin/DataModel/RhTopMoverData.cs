using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobinHoodDownload.API.Robin.DataModel
{
    public class RhTopMoverData
    {
        [JsonProperty("canonical_examples")]
        public string CanonicalExamples { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("instruments")]
        public List<string> Instruments { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("slug")]
        public string Slug { get; set; }

        [JsonProperty("membership_count")]
        public int MembershipCount { get; set; }
    }
}
