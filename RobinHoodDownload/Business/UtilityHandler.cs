using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace RobinHoodDownload.Business
{
    public class UtilityHandler
    {
        public static bool IsEmpty(string[] stringArrayValue) => (stringArrayValue == null || stringArrayValue.Length == 0);
      

        public static bool IsEmpty(string value) => (string.IsNullOrWhiteSpace(value));

        public static string GetFileName(string name)
        {
            if (!Directory.Exists(ApplicationSettings.Default.LoggingFolder))
            {
                Directory.CreateDirectory(ApplicationSettings.Default.LoggingFolder);
            }
            return $@"{ApplicationSettings.Default.LoggingFolder}\{name}";
        }

        public static string GetIdFromUrl(string url)
        {
            if (url is null)
            {
                return string.Empty;
            }
            string[] sa = url.Split("/", StringSplitOptions.RemoveEmptyEntries);
            return sa[^1];
        }

        public static DateTime GetDateValue(DateTime input)
        {
            return input;
        }

        public static DateTime GetDateValue(string input)
        {
            if (input is null || UtilityHandler.IsEmpty(input))
            {
                return DateTime.MinValue;
            }
            _ = DateTime.TryParse(input, out DateTime dt);
            return dt;
        }

        public static long GetLongNumber(string input)
        {
            return (long)GetDecimalNumber(input);
        }

        public static decimal GetDecimalNumber(string input)
        {
            if (input is null || UtilityHandler.IsEmpty(input))
            {
                return 0;
            }
            input = input.Trim()
                         .Replace("\"", string.Empty)
                         .Replace("$", string.Empty)
                         .Replace(",", string.Empty);
            _ = decimal.TryParse(input, out decimal d);
            return d;
        }


      

        public static string GetString(string input)
        {
            if (input is null)
            {
                return string.Empty;
            }
            return input.Trim();
        }

        public static DataTable GetDataTable<T>(List<T> input)
        {
            DataTable dt = new DataTable(typeof(T).Name);
            PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo prop in Props)
            {
                dt.Columns.Add(prop.Name);
            }
            foreach (T item in input)
            {
                var values = new object[Props.Length];
                for (int i = 0; i < Props.Length; i++)
                {
                    values[i] = Props[i].GetValue(item, null);
                }
                dt.Rows.Add(values);
            }
            return dt;
        }

        public static void ExportToCsvFile( DataTable input, string fileName)
        {
            List<string> data = new List<string>();
            using StreamWriter sw = new StreamWriter(fileName);
            foreach (DataColumn dc in input.Columns)
            {
                data.Add(dc.ColumnName);
            }
            sw.WriteLine(string.Join(',', data));
            foreach (DataRow row in input.Rows)
            {
                data = new List<string>();
                foreach (DataColumn dc in input.Columns)
                {
                    string s = row[dc.ColumnName].ToString().Trim();
                    if(s.Contains(","))
                    {
                        s = $"\"{s}\"";
                    }
                    data.Add(s);
                }
                sw.WriteLine(string.Join(',', data));
            }
            sw.Close();
        }

        public static void Export2Csv<T>(List<T> input, string name)
        {
            string fileName = UtilityHandler.GetFileName($"{name}.csv");
            UtilityHandler.ExportToCsvFile(UtilityHandler.GetDataTable(input), fileName);
        }


        public static DataTable CleanData(DataTable dt)
        {

            foreach (DataRow row in dt.Rows)
            {
                foreach (DataColumn dc in dt.Columns)
                {
                    string value = row[dc.ColumnName].ToString();
                    if (dc.ColumnName.ToUpper().EndsWith("DATE")
                        || dc.ColumnName.ToUpper().EndsWith("DTTM")
                       )
                    {
                        _ = DateTime.TryParse(value, out DateTime dateValue);
                        if (dateValue.Date == DateTime.MinValue)
                        {
                            row[dc.ColumnName] = DBNull.Value;
                        }
                    }
                }
            }
            return dt;
        }
    }
}
