using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobinHoodDownload.API.Robin.DataModel
{
    public class RhLegData
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("position")]
        public string Position { get; set; }

        [JsonProperty("position_type")]
        public string PositionType { get; set; }

        [JsonProperty("option")]
        public string Option { get; set; }

        [JsonProperty("ratio_quantity")]
        public int RatioQuantity { get; set; }

        [JsonProperty("expiration_date")]
        public string ExpirationDate { get; set; }

        [JsonProperty("strike_price")]
        public string StrikePrice { get; set; }

        [JsonProperty("option_type")]
        public string OptionType { get; set; }
    }
}
