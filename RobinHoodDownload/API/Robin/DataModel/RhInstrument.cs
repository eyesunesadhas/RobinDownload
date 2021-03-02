using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobinHoodDownload.API.Robin.DataModel
{
    
    public class RhInstrument
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("quote")]
        public string Quote { get; set; }

        [JsonProperty("fundamentals")]
        public string Fundamentals { get; set; }

        [JsonProperty("splits")]
        public string Splits { get; set; }

        [JsonProperty("state")]
        public string State { get; set; }

        [JsonProperty("market")]
        public string Market { get; set; }

        [JsonProperty("simple_name")]
        public string SimpleName { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("tradeable")]
        public bool Tradeable { get; set; }

        [JsonProperty("tradability")]
        public string Tradability { get; set; }

        [JsonProperty("symbol")]
        public string Symbol { get; set; }

        [JsonProperty("bloomberg_unique")]
        public string BloombergUnique { get; set; }

        [JsonProperty("margin_initial_ratio")]
        public string MarginInitialRatio { get; set; }

        [JsonProperty("maintenance_ratio")]
        public string MaintenanceRatio { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("day_trade_ratio")]
        public string DayTradeRatio { get; set; }

        [JsonProperty("list_date")]
        public string ListDate { get; set; }

        [JsonProperty("min_tick_size")]
        public object MinTickSize { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("tradable_chain_id")]
        public string TradableChainId { get; set; }

        [JsonProperty("rhs_tradability")]
        public string RhsTradability { get; set; }

        [JsonProperty("fractional_tradability")]
        public string FractionalTradability { get; set; }

        [JsonProperty("default_collar_fraction")]
        public string DefaultCollarFraction { get; set; }

        [JsonProperty("ipo_access_status")]
        public object IpoAccessStatus { get; set; }

        [JsonProperty("ipo_access_cob_deadline")]
        public object IpoAccessCobDeadline { get; set; }

        [JsonProperty("ipo_s1_url")]
        public object IpoS1Url { get; set; }
    }


}
