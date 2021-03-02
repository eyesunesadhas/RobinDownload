using Newtonsoft.Json;
using RobinHoodDownload.API.Robin.DataModel;
using RobinHoodDownload.Business;
using RobinHoodDownload.DataModels.CoreDataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace RobinHoodDownload.API.Robin
{
    public class InstrumentLookup
    {
        private static Dictionary<string, RhInstrument> lookup = new Dictionary<string, RhInstrument>();

        
        public static async Task<RhInstrument> GetRhInstrument(string url , bool OnlineLookup = false)
        {
            string instrumentID = GetInstrumentID(url);
            if (!OnlineLookup && lookup.ContainsKey(instrumentID) )
            {
                return lookup[instrumentID];
            }
            RhInstrument output = new RhInstrument();
            HttpClientHandler handler = new HttpClientHandler
            {
                UseDefaultCredentials = true
            };
            HttpClient client = new HttpClient(handler);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Add("Cache-Control", "no-cache");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            Uri requestUri = new Uri(url);
            HttpResponseMessage response = await client.GetAsync(requestUri).ConfigureAwait(false);
            if (!response.IsSuccessStatusCode)
            {
                return output;
            }
            string json = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            output = JsonConvert.DeserializeObject<RhInstrument>(json);
            instrumentID = output.Id.Trim();
            if (!(UtilityHandler.IsEmpty(instrumentID)
                   || lookup.ContainsKey(instrumentID) )
                   )
            {
                lookup.Add(instrumentID, output);
            }
            return output;

        }

        public static string GetInstrumentID(string url)
        {
            if(url is null)
            {
                return string.Empty;
            }
            string[] sa = url.Split("/", StringSplitOptions.RemoveEmptyEntries);
            return sa[^1];
        }

        public static async Task<RhInstrument> GetInstrumentValue(string instrumentID)
        {
            string url = $"https://api.robinhood.com/instruments/{instrumentID}/";
            return await GetRhInstrument(url,true);
        }
    }
}
