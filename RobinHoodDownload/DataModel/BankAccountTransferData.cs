using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobinHoodDownload.DataModel
{
	public class BankAccountTransferData
	{
		public string ID { get; set; } = string.Empty;
		public string Ref_ID { get; set; } = string.Empty;
		public int Account_ID { get; set; } = 0;
		public string BankAccount_ID { get; set; } = string.Empty;
		public decimal Transfer_AMNT { get; set; } = 0;
		public string Direction_CODE { get; set; } = string.Empty;
		public string Status_CODE { get; set; } = string.Empty;
		public decimal Fees_AMNT { get; set; } = 0;
		public DateTime Created_DTTM { get; set; }
		public DateTime Update_DTTM { get; set; }
	}
}
