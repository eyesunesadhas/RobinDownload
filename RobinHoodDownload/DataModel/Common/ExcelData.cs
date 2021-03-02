using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobinHoodDownload.DataModel.Common
{
    public class ExcelData
    {
        public string TableName { get; set; } = string.Empty;
        public string ExcelFileName { get; set; } = string.Empty;
        public int SheetNumber { get; set; } = 1;
    }
}
