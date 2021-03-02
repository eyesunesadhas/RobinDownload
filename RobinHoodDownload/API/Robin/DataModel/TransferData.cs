using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobinHoodDownload.API.Models
{
    public class TransferData
    {
        public string id { get; set; }
        public string ref_id { get; set; }
        public string url { get; set; }
        public object cancel { get; set; }
        public string ach_relationship { get; set; }
        public string account { get; set; }
        public string amount { get; set; }
        public string direction { get; set; }
        public string state { get; set; }
        public string fees { get; set; }
        public string status_description { get; set; }
        public bool scheduled { get; set; }
        public string expected_landing_date { get; set; }
        public string early_access_amount { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        public string rhs_state { get; set; }
        public object expected_sweep_at { get; set; }
        public DateTime expected_landing_datetime { get; set; }
        public object investment_schedule_id { get; set; }
    }

    //public class TransfersData
    //{
    //    public string next { get; set; }
    //    public string previous { get; set; }
    //    public List<TransferData> results { get; set; }
    //}
}
