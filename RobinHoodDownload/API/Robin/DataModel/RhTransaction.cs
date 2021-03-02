using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobinHoodDownload.API.Robin.DataModel
{
    //public class RhTransactions
    //{
    //    public string next { get; set; }
    //    public object previous { get; set; }
    //    public List<RhTransaction> results { get; set; }
    //}
    public class RhTransaction
    {
        public string id { get; set; }
        public string ref_id { get; set; }
        public string url { get; set; }
        public string account { get; set; }
        public string position { get; set; }
        public object cancel { get; set; }
        public string instrument { get; set; }
        public string cumulative_quantity { get; set; }
        public string average_price { get; set; }
        public string fees { get; set; }
        public string state { get; set; }
        public string type { get; set; }
        public string side { get; set; }
        public string time_in_force { get; set; }
        public string trigger { get; set; }
        public string price { get; set; }
        public object stop_price { get; set; }
        public string quantity { get; set; }
        public object reject_reason { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        public DateTime last_transaction_at { get; set; }
        public List<Execution> executions { get; set; }
        public bool extended_hours { get; set; }
        public bool override_dtbp_checks { get; set; }
        public bool override_day_trade_checks { get; set; }
        public string response_category { get; set; }
        public object stop_triggered_at { get; set; }
        public object last_trail_price { get; set; }
        public object last_trail_price_updated_at { get; set; }
        public object dollar_based_amount { get; set; }
        public object drip_dividend_id { get; set; }
        public TotalNotional total_notional { get; set; }
        public ExecutedNotional executed_notional { get; set; }
        public object investment_schedule_id { get; set; }
    }

    public class Execution
    {
        public string price { get; set; }
        public string quantity { get; set; }
        public string settlement_date { get; set; }
        public DateTime timestamp { get; set; }
        public string id { get; set; }
    }

    public class TotalNotional
    {
        public string amount { get; set; }
        public string currency_code { get; set; }
        public string currency_id { get; set; }
    }

    public class ExecutedNotional
    {
        public string amount { get; set; }
        public string currency_code { get; set; }
        public string currency_id { get; set; }
    }
}
