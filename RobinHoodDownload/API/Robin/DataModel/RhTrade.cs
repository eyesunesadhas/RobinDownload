
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobinHoodDownload.API.Robin.DataModel
{
    //public class RhTrades
    //{
    //    public List<RhTrade> results { get; set; }
    //}

    public class RhTrade
    {
        [JsonProperty("ask_price")]
        public string AskPrice { get; set; }

        [JsonProperty("ask_size")]
        public int AskSize { get; set; }

        [JsonProperty("bid_price")]
        public string BidPrice { get; set; }

        [JsonProperty("bid_size")]
        public int BidSize { get; set; }

        [JsonProperty("last_trade_price")]
        public string LastTradePrice { get; set; }

        [JsonProperty("last_extended_hours_trade_price")]
        public string LastExtendedHoursTradePrice { get; set; }

        [JsonProperty("previous_close")]
        public string PreviousClose { get; set; }

        [JsonProperty("adjusted_previous_close")]
        public string AdjustedPreviousClose { get; set; }

        [JsonProperty("previous_close_date")]
        public string PreviousCloseDate { get; set; }

        [JsonProperty("symbol")]
        public string Symbol { get; set; }

        [JsonProperty("trading_halted")]
        public bool TradingHalted { get; set; }

        [JsonProperty("has_traded")]
        public bool HasTraded { get; set; }

        [JsonProperty("last_trade_price_source")]
        public string LastTradePriceSource { get; set; }

        [JsonProperty("updated_at")]
        public DateTime UpdatedAt { get; set; }

        [JsonProperty("instrument")]
        public string Instrument { get; set; }

        [JsonProperty("instrument_id")]
        public string InstrumentID { get; set; }

    }
}
