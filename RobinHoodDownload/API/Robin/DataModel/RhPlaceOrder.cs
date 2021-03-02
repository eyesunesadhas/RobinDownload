using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobinHoodDownload.API.Robin.DataModel
{
    public class RhPlaceOrder
    {
        [JsonProperty("account")]
        public string Account { get; set; }

        [JsonProperty("instrument")]
        public string Instrument { get; set; }

        [JsonProperty("price")]
        public decimal Price { get; set; }

        [JsonProperty("stop_price")]
        public decimal StopPrice { get; set; }

        [JsonProperty("quantity")]
        public decimal Quantity { get; set; }

        [JsonProperty("side")]
        public string Side { get; set; }

        [JsonProperty("symbol")]
        public string Symbol { get; set; }

        [JsonProperty("time_in_force")]
        public string TimeInForce { get; set; }

        [JsonProperty("trigger")]
        public string Trigger { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        /*
        [JsonProperty("extended_hours")]
        public bool ExtendedHours { get; set; } = true;

        [JsonProperty("override_day_trade_checks")]
        public bool OverrideDayTradeChecks { get; set; } = true;
        */

    }
}