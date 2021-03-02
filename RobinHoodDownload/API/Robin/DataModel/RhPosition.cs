using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobinHoodDownload.API.Robin.DataModel
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
    //public class RhPositions
    //{
    //    public string next { get; set; }
    //    public string previous { get; set; }
    //    public List<RhPosition> results { get; set; }
    //}
    public class RhPosition
    {
        public string url { get; set; }
        public string instrument { get; set; }
        public string account { get; set; }
        public string account_number { get; set; }
        public string average_buy_price { get; set; }
        public string pending_average_buy_price { get; set; }
        public string quantity { get; set; }
        public string intraday_average_buy_price { get; set; }
        public string intraday_quantity { get; set; }
        public string shares_available_for_exercise { get; set; }
        public string shares_held_for_buys { get; set; }
        public string shares_held_for_sells { get; set; }
        public string shares_held_for_stock_grants { get; set; }
        public string shares_held_for_options_collateral { get; set; }
        public string shares_held_for_options_events { get; set; }
        public string shares_pending_from_options_events { get; set; }
        public string shares_available_for_closing_short_position { get; set; }
        public DateTime updated_at { get; set; }
        public DateTime created_at { get; set; }
    }
}
