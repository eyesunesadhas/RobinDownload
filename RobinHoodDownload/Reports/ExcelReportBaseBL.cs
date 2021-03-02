using ClosedXML.Excel;
using RobinHoodDownload.ExcelExport;
using RobinHoodDownload.Properties;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobinHoodDownload.Business.Share.Reports
{
    public class ExcelReportBaseBL
    {
        public enum ReportType
        {
            Excel,
            GoogleSheet
        }
        public ReportType ViewType { get; set; } = ReportType.Excel;


        public static DataTable GetDataSet(DataTable src, string tableName, List<ExcelColumn> columns)
        {

            DataTable output = new DataTable(tableName);
            foreach (ExcelColumn rc in columns)
            {
                output.Columns.Add(rc.ColumnName, rc.DataType);
            }

            foreach (DataRow row in src.Rows)
            {
                DataRow r = output.NewRow();
                foreach (DataColumn dc in output.Columns)
                {
                    if (src.Columns.Contains(dc.ColumnName))
                    {
                        r[dc.ColumnName] = row[dc.ColumnName];
                    }
                }
                output.Rows.Add(r);
            }

            //Change the display Name 
            foreach (ExcelColumn col in columns)
            {
                if (UtilityHandler.IsEmpty(col.DisplayName))
                {
                    continue;
                }
                if (col.ColumnName != col.DisplayName
                    && output.Columns.Contains(col.ColumnName))
                {
                    output.Columns[col.ColumnName].ColumnName = col.DisplayName;
                }
            }
            return output;
        }

        protected virtual void FormatExcelSheet(XLWorkbook book)
        {
            foreach (IXLWorksheet sheet in book.Worksheets)
            {
                int colUsed = sheet.LastColumnUsed().ColumnNumber();
                int rowUsed = sheet.LastRowUsed().RowNumber();
                FormatWorkSheet(sheet, colUsed, rowUsed);
            }
        }

        protected static void SetNumberFormat(IXLRange range, string format)
        {
            if (range == null)
            {
                return;
            }
            range.Style.NumberFormat.Format = format;
            range.DataType = XLDataType.Number;
        }


        protected virtual string GetExcelFileName()
        {
            return string.Empty;
        }
        protected virtual void FormatWorkSheet(IXLWorksheet sheet, int colUsed, int rowUsed)
        {

        }


        protected virtual DataTable GetDataTable(string tableName, DataTable src, List<ExcelColumn> columns)
        {

            DataTable des = new DataTable(tableName);
            foreach (ExcelColumn rc in columns)
            {
                des.Columns.Add(rc.ColumnName, rc.DataType);
            }
            foreach (DataRow row in src.Rows)
            {
                DataRow r = des.NewRow();
                foreach (DataColumn dc in des.Columns)
                {
                    if (src.Columns.Contains(dc.ColumnName))
                    {
                        r[dc.ColumnName] = row[dc.ColumnName];
                    }
                }
                des.Rows.Add(r);
            }

            //Change the display Name 
            foreach (ExcelColumn col in columns)
            {
                if (UtilityHandler.IsEmpty(col.DisplayName))
                {
                    continue;
                }
                if (col.ColumnName != col.DisplayName
                    && des.Columns.Contains(col.ColumnName))
                {
                    des.Columns[col.ColumnName].ColumnName = col.DisplayName;
                }
            }
            return UtilityHandler.CleanData(des);
        }

       

        protected virtual string BuildExcelReport(DataSet ds)
        {
            string fileName = GetExcelFileName();
            using (XLWorkbook book = new XLWorkbook())
            {
                foreach (DataTable dt in ds.Tables)
                {
                    string sheetName = dt.TableName;

                    DataTable dtc = UtilityHandler.CleanData(dt);
                    book.Worksheets.Add(dtc, sheetName);
                }
                FormatExcelSheet(book);
                book.SaveAs(fileName);
            }
            return fileName;
        }

        public virtual string ExportExcel()
        {
            return string.Empty;
        }

      
        protected virtual void SetBorderAndBackground(IXLRange range)
        {
            range.Style.Fill.BackgroundColor = XLColor.LightGray;
            foreach (IXLCell c in range.Cells())
            {
                SetBorder(c);
            }
        }

        protected static void SetBuySellConditionalFormat(IXLRange range)
        {
            if (range == null)
            {
                return;
            }
            range.AddConditionalFormat().WhenEquals("SELL").Font.FontColor = XLColor.Red;
            range.AddConditionalFormat().WhenEquals("BUY").Font.FontColor = XLColor.Green;
        }

        protected static void SetBorder(IXLCell cell)
        {
            cell.Style.Border.TopBorder = XLBorderStyleValues.Thin;
            cell.Style.Border.LeftBorder = XLBorderStyleValues.Thin;
            cell.Style.Border.RightBorder = XLBorderStyleValues.Thin;
            cell.Style.Border.BottomBorder = XLBorderStyleValues.Thin;
        }

        public static IXLWorksheet GetSheet(IXLWorksheets worksheets, string sheetName)
        {
            if (worksheets == null)
            {
                return null;
            }
            foreach (IXLWorksheet sheet in worksheets)
            {
                if (sheet.Name == sheetName)
                {
                    return sheet;
                }
            }
            return null;
        }

        public static string GetExcelFileName(string name)
        {
            string fileName = $@"{Settings.Default.LoggingFolder}\{name}.xlsx";
            if (File.Exists(fileName))
            {
                File.Delete(fileName);
            }
            return fileName;
        }

        protected static void SetAccountTallyConditionalFormat(IXLRange range)
        {
            if (range == null)
            {
                return;
            }
            range.AddConditionalFormat().WhenEquals("Yes").Font.FontColor = XLColor.Green;
            range.AddConditionalFormat().WhenEquals("No").Font.FontColor = XLColor.Red;
        }

        protected static void SetDateFormat(IXLRange range, string format)
        {
            if (range is null)
            {
                return;
            }
            range.DataType = XLDataType.DateTime;
            range.Style.NumberFormat.Format = format;

        }

        protected static void SetProfitConditionalFormat(IXLRange range)
        {
            if (range is null)
            {
                return;
            }
            range.AddConditionalFormat().WhenLessThan(0).Font.FontColor = XLColor.Red;
            range.AddConditionalFormat().WhenEqualOrGreaterThan(0).Font.FontColor = XLColor.Green;
        }

        protected static void SetExpireDateConditionalFormat(IXLRange range)
        {
            if (range is null)
            {
                return;
            }
            
        }

        protected static void SetTargetMetConditionalFormat(IXLRange range)
        {
            if (range == null)
            {
                return;
            }
            range.AddConditionalFormat().WhenEquals("Yes").Font.FontColor = XLColor.Green;
        }

        protected static void SetTradeConditionalFormat(IXLRange range)
        {
            if (range == null)
            {
                return;
            }
            range.AddConditionalFormat().WhenEquals("BUY").Font.FontColor = XLColor.Green;
            range.AddConditionalFormat().WhenEquals("SELL").Font.FontColor = XLColor.Red;
        }
    }
}
