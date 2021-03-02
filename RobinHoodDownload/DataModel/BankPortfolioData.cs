using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobinHoodDownload.DataModel
{
    public class BankPortfolioData
    {
        public string BankAccount_ID { get; set; } = string.Empty;
        public string Trade_CODE { get; set; } = string.Empty;
        public string Trade_NAME { get; set; } = string.Empty;
        public decimal Shares_CNT { get; set; } = 0;
        public decimal CostBasis_AMNT { get; set; } = 0;
        public decimal Value_AMNT { get; set; } = 0;
        public string Instrument_ID { get; set; } = string.Empty;
        public DateTime Export_DATE { get; set; } = DateTime.Today;
    }
}
