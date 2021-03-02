using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobinHoodDownload.API.Robin.DataModel
{
    public class RhOptionData
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("chain")]
        public string Chain { get; set; }

        [JsonProperty("account")]
        public string Account { get; set; }

        [JsonProperty("symbol")]
        public string Symbol { get; set; }

        [JsonProperty("strategy")]
        public string Strategy { get; set; }

        [JsonProperty("average_open_price")]
        public string AverageOpenPrice { get; set; }

        [JsonProperty("legs")]
        public List<RhLegData> Legs { get; set; }

        [JsonProperty("quantity")]
        public string Quantity { get; set; }

        [JsonProperty("intraday_average_open_price")]
        public string IntradayAverageOpenPrice { get; set; }

        [JsonProperty("intraday_quantity")]
        public string IntradayQuantity { get; set; }

        [JsonProperty("direction")]
        public string Direction { get; set; }

        [JsonProperty("intraday_direction")]
        public string IntradayDirection { get; set; }

        [JsonProperty("trade_value_multiplier")]
        public string TradeValueMultiplier { get; set; }

        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("updated_at")]
        public DateTime UpdatedAt { get; set; }
    }
}
