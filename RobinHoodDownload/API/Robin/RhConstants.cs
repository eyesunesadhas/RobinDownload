using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobinHoodDownload.API.Robin
{
    public class RhConstants
    {
        public const string SIDE_BUY = "buy";
        public const string SIDE_SELL = "sell";

  
        public const string TIME_FORCE_EOD = "gfd";
        public const string TIME_FORCE_UNTIL_CANCEL = "gtc";

        public const string TRIGGER_TYPE_IMMEDIATE = "immediate";
        public const string TRIGGER_TYPE_STOP = "stop";

        public const string ORDER_TYPE_LIMIT= "limit";
        public const string ORDER_TYPE_MARKET = "market";
        public const string ORDER_TYPE_STOP_LOSS = "stoploss";


    }
}
