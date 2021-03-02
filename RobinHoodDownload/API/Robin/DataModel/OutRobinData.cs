using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobinHoodDownload.API.Models
{


    public class OutRobinData<T> 
    {

        [JsonProperty("next")]
        public string Next { get; set; }
        [JsonProperty("previous")]
        public string Previous { get; set; }

        [JsonProperty("results")]
        public List<T> Data { get; set; }

        [JsonProperty("count")]
        public int Count { get; set; }
        public OutRobinData()
        {
        }


    }
}
