using Newtonsoft.Json;
using RobinHoodUI.Api.DataModel;
using RobinHoodDownload.API;
using RobinHoodDownload.API.Models;
using RobinHoodDownload.API.Robin.DataModel;

using RobinHoodDownload.DataModel.Common;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using RobinHoodDownload.Business;

namespace RobinHoodUI.Api
{
    public class RobinhoodApi : ApiBase
    {

        // https://github.com/sanko/Robinhood (Documentation)
        //https://json2csharp.com/
        public RobinhoodApi(string apibaseUrl = null, string bearerToken = null) :
             base(apibaseUrl, bearerToken)
        {
            this.ApiBaseUrl = (apibaseUrl is null) ? "https://api.robinhood.com" : apibaseUrl;
        }

        public async Task<OutRobinData<RhAccount>> GetAccount()
        {
            OutData<string> data = await GetJsonData($"accounts/");
            if (data.StatusList.Count > 0)
            {
                throw new ApplicationException(data.StatusList[0].Description);
            }
            LogJsonData("Accounts", data.Data);
            return JsonConvert.DeserializeObject<OutRobinData<RhAccount>>(data.Data);
        }

        public async Task<OutRobinData<RhMoverData>> GetSp500Mover(string direction)
        {
            OutData<string> data = await GetJsonData($"midlands/movers/sp500/?direction={direction}");
            if (data.StatusList.Count > 0)
            {
                throw new ApplicationException($"{data.StatusList[0].Code} - {data.StatusList[0].Description}");
            }
            LogJsonData($"Mover_{direction}", data.Data);
            return JsonConvert.DeserializeObject<OutRobinData<RhMoverData>>(data.Data);
        }

        public async Task<RhTopMoverData> GetTagData(string tag)
        {
            OutData<string> data = await GetJsonData($"midlands/tags/tag/{tag}/");
            if (data.StatusList.Count > 0)
            {
                throw new ApplicationException($"{data.StatusList[0].Code} - {data.StatusList[0].Description}");
            }
            LogJsonData($"Tag_{tag.Replace("-","_")}", data.Data);
            return JsonConvert.DeserializeObject<RhTopMoverData>(data.Data);
        }

        public async Task<OutData<string>> GetTopMoverString()
        {
           return await GetJsonData($"midlands/tags/tag/top-movers/");
        }

        public async Task<RhFundamental> GetFundamental(string input)
        {
            if (UtilityHandler.IsEmpty(input))
            {
                return new RhFundamental();
            }
            OutData<string> data = await GetJsonData($"fundamentals/{input.Trim()}/");
            if (data.StatusList.Count > 0)
            {
                throw new ApplicationException($"{data.StatusList[0].Code} - {data.StatusList[0].Description}");
            }
            LogJsonData($"Fundamental_{input}", data.Data);
            return JsonConvert.DeserializeObject<RhFundamental>(data.Data);
        }

        const int MAX_SYMBOL = 100;
        public async Task<OutRobinData<RhFundamental>> GetFundamental(List<string> input)
        {
            if (input.Count == 0)
            {
                return new OutRobinData<RhFundamental>();
            }
            OutRobinData<RhFundamental> output = new OutRobinData<RhFundamental>
            {
                Data = new List<RhFundamental>()
            };
            List<List<string>> parts = SplitList(input, MAX_SYMBOL);
            int i = 1;
            foreach(List<string> part in parts) 
            { 
                string symbols = string.Join(",", part);
                OutData<string> data = await GetJsonData($"fundamentals/?symbols={symbols}");
                if (data.StatusList.Count > 0)
                {
                    throw new ApplicationException($"{data.StatusList[0].Code} - {data.StatusList[0].Description}");
                }
                LogJsonData($"Fundamentals{i}", data.Data);
                i++;
                OutRobinData<RhFundamental> partData = JsonConvert.DeserializeObject<OutRobinData<RhFundamental>>(data.Data);
                if(partData.Data is not null && partData.Data.Count > 0)
                {
                    output.Data.AddRange(partData.Data);
                }
            }
            return output;
        }
        public static List<List<string>> SplitList(List<string> input, int blockSize)
        {
            List<List<string>> output = new List<List<string>>();
            for (int i = 0; i < input.Count; i += blockSize)
            {
                output.Add(input.GetRange(i, Math.Min(blockSize, input.Count - i)));
            }
            return output;
        }

        public async Task<RhInstrument> GetInstrumentData(string url)
        {

            OutData<string> data = await GetJsonData4Url(url);
            if (data.StatusList.Count > 0)
            {
                throw new ApplicationException($"{data.StatusList[0].Code} - {data.StatusList[0].Description}");
            }
            LogJsonData("Instrument_ID", data.Data);
            return JsonConvert.DeserializeObject<RhInstrument>(data.Data);
        }
       
        public async Task<RhTrade> GetQuote(string symbol)
        {
            if(UtilityHandler.IsEmpty(symbol) )
            {
                return new RhTrade();
            }
            OutData<string> data = await GetJsonData($"quotes/{symbol}/");
            if (data.StatusList.Count > 0)
            {
                throw new ApplicationException(data.StatusList[0].Description);
            }
            LogJsonData($"Quote_{symbol}", data.Data);
            return JsonConvert.DeserializeObject<RhTrade> (data.Data);
        }
        public async Task<OutRobinData<RhTrade>> GetQuotes(List<string> input)
        {
            if (input.Count == 0)
            {
                return new OutRobinData<RhTrade>();
            }
            string symbols = string.Join(",", input);
            OutData<string> data = await GetJsonData($"quotes/?symbols={symbols}");
            if (data.StatusList.Count > 0)
            {
                throw new ApplicationException(data.StatusList[0].Description);
            }
            LogJsonData("Quotes", data.Data);
            return JsonConvert.DeserializeObject<OutRobinData<RhTrade>>(data.Data);
        }

        // https://github.com/sanko/Robinhood/blob/master/Order.md
        public async Task<OutRobinData<RhTransaction>> GetOrders()
        {
            OutData<string> data = await GetJsonData($"orders/");
            if (data.StatusList.Count > 0)
            {
                throw new ApplicationException(data.StatusList[0].Description);
            }
            LogJsonData("Orders", data.Data);
            return  JsonConvert.DeserializeObject<OutRobinData<RhTransaction>>(data.Data);
            
        }

        public async Task<string> PlaceSingleOrder(RhPlaceOrder input)
        {
            string output = await PostJsonData<RhPlaceOrder>($"orders/", input);
            LogJsonData($"PlaceOrder_{input?.Symbol}", output);
            return output;
        }

        public async Task<OutRobinData<RhOptionData>> GetOptionOrderData()
        {
            OutData<string> data = await GetJsonData($"options/aggregate_positions/");
            LogJsonData("OptionOrders", data.Data);
            return JsonConvert.DeserializeObject<OutRobinData<RhOptionData>>(data.Data);
        }


        public async Task<OutRobinData<TransferData>> GetBankTransfers()
        {
            OutData<string> data = await GetJsonData($"ach/transfers/");
            LogJsonData("Transfers", data.Data);
            return JsonConvert.DeserializeObject<OutRobinData<TransferData>>(data.Data);
        }

        public async Task<OutRobinData<RhPosition>> GetPositions()
        {
            OutData<string> data = await GetJsonData($"positions/");
            if (data.StatusList.Count > 0)
            {
                throw new ApplicationException(data.StatusList[0].Description);
            }
            return JsonConvert.DeserializeObject<OutRobinData<RhPosition>>(data.Data);
        }
        public async Task<OutData<string>> GetPositionsString()
        {
            return await GetJsonData($"positions/");
        }

        public async Task<OutData<string>> GetWatchlists()
        {
            return await GetJsonData($"watchlists/Invest2021/");
        }

       
    }
}
