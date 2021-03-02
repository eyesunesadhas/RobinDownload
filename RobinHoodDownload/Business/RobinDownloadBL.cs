using Newtonsoft.Json;
using RobinHoodDownload.API.Models;
using RobinHoodDownload.API.Robin;
using RobinHoodDownload.API.Robin.DataModel;
using RobinHoodDownload.DataModel;
using RobinHoodDownload.DataModel.Common;
using RobinHoodDownload.Properties;
using RobinHoodUI.Api;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobinHoodDownload.Business
{
    public delegate void MessageHandler(string message);
    public class RobinDownloadBL
    {
        public MessageHandler feedback;
        public void ShowMessage(string message)
        {
            feedback?.Invoke(message);
        }
        public async Task<List<BankAccountTransferData>> GetBankTransfer()
        {
            RobinhoodApi robinhoodApi = new RobinhoodApi()
            {
                BearerToken = ApplicationSettings.Default.RobinKey
            };
            OutRobinData<TransferData> datas = await robinhoodApi.GetBankTransfers();
            List<BankAccountTransferData> output = new List<BankAccountTransferData>();
            foreach (TransferData data in datas.Data)
            {

                ShowMessage($"{data.direction} -  {data.amount} on {data.scheduled}");
                DateTime createDate = UtilityHandler.GetDateValue(data.created_at);
                DateTime updateDate = UtilityHandler.GetDateValue(data.updated_at);
                decimal transferAmnt = UtilityHandler.GetDecimalNumber(data.amount);
                decimal feeAmnt = UtilityHandler.GetDecimalNumber(data.fees);
                BankAccountTransferData d = new BankAccountTransferData()
                {
                    ID = data.id,
                    Ref_ID = data.ref_id,
                    Transfer_AMNT = transferAmnt,
                    Fees_AMNT = feeAmnt,
                    BankAccount_ID = UtilityHandler.GetIdFromUrl(data.account),
                    Direction_CODE = data.direction,
                    Status_CODE = data.state,
                    Created_DTTM = createDate,
                    Update_DTTM = updateDate
                };
                output.Add(d);
            }
            return output;
        }
        public async Task<List<BankPortfolioData>> GetPositionData()
        {
            List<BankPortfolioData> output = new List<BankPortfolioData>();
            RobinhoodApi api = new RobinhoodApi()
            {
                BearerToken = ApplicationSettings.Default.RobinKey
            };
            OutRobinData<RhPosition> datas = await api.GetPositions();
            foreach (RhPosition data in datas.Data)
            {
                RhInstrument inst = await InstrumentLookup.GetRhInstrument(data.instrument);
                ShowMessage($"{inst.Symbol}- {inst.SimpleName}");
                decimal shareCount = UtilityHandler.GetDecimalNumber(data.quantity);
                decimal costBasis = UtilityHandler.GetDecimalNumber(data.average_buy_price);
                BankPortfolioData d = new BankPortfolioData()
                {
                    BankAccount_ID = UtilityHandler.GetString(data.account_number),
                    Trade_CODE = UtilityHandler.GetString(inst.Symbol),
                    Trade_NAME = UtilityHandler.GetString(inst.SimpleName),
                    Shares_CNT = shareCount,
                    CostBasis_AMNT = costBasis,
                    Value_AMNT = shareCount * costBasis,
                    Export_DATE = DateTime.Today,
                    Instrument_ID = inst.Id
                };
                output.Add(d);
            }
            return output;
        }
        private async Task<List<BankTransactionData>> Convert2BankTransactionData(OutRobinData<RhTransaction> datas)
        {
            List<BankTransactionData> output = new List<BankTransactionData>();
            foreach (RhTransaction data in datas.Data)
            {
                string accountID = UtilityHandler.GetIdFromUrl(data.account);
                RhInstrument inst = await InstrumentLookup.GetRhInstrument(data.instrument);
                decimal valueAmt = UtilityHandler.GetDecimalNumber(data?.executed_notional?.amount);
                if (data.state == "cancelled")
                {
                    ShowMessage($"{inst.Symbol} [{data.side.ToUpper()}] - {inst.SimpleName}");
                    BankTransactionData d = new BankTransactionData()
                    {
                        BankAccount_ID = accountID,
                        TransAction_DATE = UtilityHandler.GetDateValue(data.created_at),
                        TransAction_CODE = UtilityHandler.GetString(data.side).ToUpper(),
                        Settlement_DATE = UtilityHandler.GetDateValue(data.updated_at),
                        Trade_CODE = UtilityHandler.GetString(inst.Symbol),
                        Trade_NAME = UtilityHandler.GetString(inst.SimpleName),
                        Instrument_ID = UtilityHandler.GetString(inst.Id),
                        Trade_ID = string.Empty,
                        Shares_CNT = UtilityHandler.GetDecimalNumber(data.quantity),
                        CostBasis_AMNT = UtilityHandler.GetDecimalNumber(data.price),
                        Value_AMNT = valueAmt,
                        Type_CODE = UtilityHandler.GetString(data.type),
                        GoodUntil_CODE = UtilityHandler.GetString(data.time_in_force),
                        State_CODE = UtilityHandler.GetString(data.state),
                        Export_DATE = DateTime.Today
                    };
                    output.Add(d);
                    continue;
                }
                if (data.executions is null)
                {
                    continue;
                }
                foreach (Execution e in data.executions)
                {
                    ShowMessage($"{inst.Symbol} [{data.side.ToUpper()}] - {inst.SimpleName}");
                    BankTransactionData d = new BankTransactionData()
                    {
                        BankAccount_ID = accountID,
                        TransAction_DATE = data.executions[0].timestamp,
                        TransAction_CODE = UtilityHandler.GetString(data.side).ToUpper(),
                        Settlement_DATE = UtilityHandler.GetDateValue(data.executions[0].settlement_date),
                        Trade_CODE = UtilityHandler.GetString(inst.Symbol),
                        Trade_NAME = UtilityHandler.GetString(inst.SimpleName),
                        Instrument_ID = UtilityHandler.GetString(inst.Id),
                        Trade_ID = UtilityHandler.GetString(e.id),
                        Shares_CNT = UtilityHandler.GetDecimalNumber(e.quantity),
                        CostBasis_AMNT = UtilityHandler.GetDecimalNumber(e.price),
                        Value_AMNT = valueAmt,
                        Type_CODE = UtilityHandler.GetString(data.type),
                        GoodUntil_CODE = UtilityHandler.GetString(data.time_in_force),
                        State_CODE = UtilityHandler.GetString(data.state),
                        Export_DATE = DateTime.Today
                    };
                    output.Add(d);
                }
            }
            int seqNumb = output.Count;
            foreach (BankTransactionData row in output)
            {
                row.Seq_NUMB = seqNumb; seqNumb--;
            }
            return output;
        }

        public async Task<List<BankTransactionData>> GetTransactionData()
        {
            OutRobinData<RhTransaction> datas = await GetRobinHoodTransactionData();
            return  await Convert2BankTransactionData(datas);
        }

       

        private static async Task<OutRobinData<RhTransaction>> GetRobinHoodTransactionData()
        {

            OutRobinData<RhTransaction> output = new OutRobinData<RhTransaction>()
            {
                Data = new List<RhTransaction>()
            };
            RobinhoodApi api = new RobinhoodApi()
            {
                BearerToken = ApplicationSettings.Default.RobinKey
            };
            string downloadUrl = "https://api.robinhood.com/orders/";
            string folderName = $@"{ApplicationSettings.Default.LoggingFolder}\ApiData";
            if (!Directory.Exists(folderName))
            {
                Directory.CreateDirectory(folderName);
            }
            for (int i = 0; i < Settings.Default.RobinMaxPages; i++)
            {

                string tranFileName = $@"{folderName}\Orders{i}.json";
                OutData<string> sd = await api.GetJsonData4Url(downloadUrl);
                File.WriteAllText(tranFileName, sd.Data);
                OutRobinData<RhTransaction> datas = JsonConvert.DeserializeObject<OutRobinData<RhTransaction>>(sd.Data);
                if (datas.Data.Count > 0)
                {
                    output.Data.AddRange(datas.Data);
                }
                if (datas.Next is null || UtilityHandler.IsEmpty(datas.Next))
                {
                    break;
                }
                downloadUrl = datas.Next;
            }
            return output;
        }

    }
}
