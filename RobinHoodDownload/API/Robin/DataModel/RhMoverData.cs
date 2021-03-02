using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobinHoodDownload.API.Robin.DataModel
{
  
    public class RhMoverData
    {
        [JsonProperty("instrument_url")]
        public string InstrumentUrl { get; set; }

        [JsonProperty("symbol")]
        public string Symbol { get; set; }

        [JsonProperty("updated_at")]
        public DateTime UpdatedAt { get; set; }

        [JsonProperty("price_movement")]
        public PriceMovement PriceMovement { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }
    }

    public class PriceMovement
    {
        [JsonProperty("market_hours_last_movement_pct")]
        public string MarketHoursLastMovementPct { get; set; }

        [JsonProperty("market_hours_last_price")]
        public string MarketHoursLastPrice { get; set; }
    }

}
