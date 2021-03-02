using RobinHoodDownload.Business;
using RobinHoodDownload.DataModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RobinHoodDownload
{
    public partial class RobinDownload : Form
    {
        public RobinDownload()
        {
            InitializeComponent();
        }

        private async void ToolExcel_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                ShowMessage("Please Wait...");
                if (!ValidateData())
                {
                    return;
                }
                ApplicationSettings.Default.RobinKey = RobinKey.Text.Trim();
                RobinDownloadBL downloadBL = new RobinDownloadBL();
                downloadBL.feedback += ShowMessage;
                ShowMessage("Download Position Data");
                List<BankPortfolioData> postions = await downloadBL.GetPositionData();
                UtilityHandler.Export2Csv(postions, "Position");
                ShowMessage("Download Transaction Data");
                List<BankTransactionData> transaction = await downloadBL.GetTransactionData();
                UtilityHandler.Export2Csv(transaction, "Transaction");
                List<BankAccountTransferData> transfer = await downloadBL.GetBankTransfer();
                UtilityHandler.Export2Csv(transfer, "Transfer");
                ShowMessage($"Exported in {ApplicationSettings.Default.LoggingFolder} folder");
            }
            catch (Exception ex)
            {
                ShowMessage(ex.Message);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }


        }

        private bool ValidateData()
        {
            if (UtilityHandler.IsEmpty(RobinKey.Text.Trim()))
            {
                ShowMessage("Enter the Bearer token");
                return false;
            }
            return true;
        }

        private void ShowMessage(string msg)
        {
            lblMessage.Text = msg;
        }
    }
}
