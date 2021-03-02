using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobinHoodDownload.API.Robin.DataModel
{
    public class InstrumentData
    {

        [JsonProperty("url")]
        public string Url { get; set; } = string.Empty;

        [JsonProperty("symbol")]
        public string Symbol { get; set; } = string.Empty;
        
    }
}
