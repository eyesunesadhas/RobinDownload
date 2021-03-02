using Newtonsoft.Json;

using RobinHoodDownload.DataModel.Common;
using RobinHoodDownload.Properties;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace RobinHoodDownload.API
{
    public class ApiBase
    {
        public string ApiBaseUrl { get; set; } = string.Empty;
        public string BearerToken { get; set; } = string.Empty;
        private ApiBase()
        {

        }
        public ApiBase(string apibaseUrl , string bearerToken)
        {
            this.ApiBaseUrl = apibaseUrl;
            this.BearerToken = bearerToken;
        }
    
        public HttpClient GetHttpClient(bool isNeedBearer = true)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            if (!string.IsNullOrEmpty(BearerToken) && isNeedBearer)
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", BearerToken);
            }
            return client;
        }

        public HttpClient GetRobinHttpClient(bool isNeedBearer = true)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            if (!string.IsNullOrEmpty(BearerToken) && isNeedBearer)
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", BearerToken);
                client.DefaultRequestHeaders.Referrer = new Uri("https://robinhood.com/");
                client.DefaultRequestHeaders.Host = "api.robinhood.com";
                
            }
            return client;
        }

        public async Task<OutData<string>> GetJsonData4Url(string url)
        {
            HttpClient client = GetHttpClient();
            OutData<string> output = new OutData<string>();
            HttpResponseMessage response = await client.GetAsync(url);
            if (response.StatusCode != HttpStatusCode.OK)
            {
                if (response.StatusCode == HttpStatusCode.Unauthorized)
                {
                    throw new ApplicationException("Unauthorized access");
                }
                throw new ApplicationException($"{response.StatusCode} - {response.ReasonPhrase}");
            }
            output.Data = await response.Content.ReadAsStringAsync();
            return output;
        }

        protected static void LogJsonData(string name, string input)
        {
            if (Settings.Default.IsLogOnFileSystem)
            {
                string folderName = $@"{Settings.Default.LoggingFolder}\ApiData\";
                if (!Directory.Exists(folderName))
                {
                    Directory.CreateDirectory(folderName);
                }
                string fileName = $@"{folderName}\{name}.json";
                File.WriteAllText(fileName, input);
            }
        }

        public async Task<OutData<string>> GetJsonData(string api )
        {
            string apiEndPoint = $"{ApiBaseUrl}/{api}";
            return await GetJsonData4Url(apiEndPoint);
        }

        public async Task<string> PostJsonData<T>(string api,T input )
        {
            string apiEndPoint = $"{ApiBaseUrl}/{api}";
            using HttpClient client = GetHttpClient();
            HttpResponseMessage response = await client.PostAsJsonAsync<T>(apiEndPoint, input);
            if (response.StatusCode != HttpStatusCode.OK)
            {
                    if (response.StatusCode == HttpStatusCode.Unauthorized)
                    {
                        throw new ApplicationException("Unauthorized access");
                    }
                    throw new ApplicationException($"{response.StatusCode} - {response.ReasonPhrase}");
            }
            return  await response.Content.ReadAsStringAsync();
        }

       

    }
}
