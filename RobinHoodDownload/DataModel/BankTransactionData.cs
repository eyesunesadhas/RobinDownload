using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobinHoodDownload.DataModel
{
    public class BankTransactionData
    {
        public string BankAccount_ID { get; set; } = string.Empty;
        public string Trade_CODE { get; set; } = string.Empty;
        public string Trade_NAME { get; set; } = string.Empty;
        public string Instrument_ID { get; set; } = string.Empty;
        public string Trade_ID { get; set; } = string.Empty;
        public string TransAction_CODE { get; set; } = string.Empty;
        public DateTime TransAction_DATE { get; set; } = DateTime.Today;
        public DateTime Settlement_DATE { get; set; } = DateTime.Today;
        public decimal Shares_CNT { get; set; } = 0;
        public decimal CostBasis_AMNT { get; set; } = 0;
        public decimal Value_AMNT { get; set; } = 0;
        public DateTime Export_DATE { get; set; } = DateTime.Today;
        public int Seq_NUMB { get; set; } = 0;
        public string Type_CODE { get; set; } = string.Empty;
        public string GoodUntil_CODE { get; set; } = string.Empty;
        public string State_CODE { get; set; } = string.Empty;
    }
}
