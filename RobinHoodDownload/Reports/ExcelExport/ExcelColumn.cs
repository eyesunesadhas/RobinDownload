using System;

namespace RobinHoodDownload.ExcelExport
{
    public class ExcelColumn
    {
        public string ColumnName { get; set; } = string.Empty;
        public string DisplayName { get; set; } = string.Empty;
        public string Alignment { get; set; } = "left";
        public Type DataType { get; set; } = Type.GetType("System.String");
        public float Width { get; set; } = 1;
        public string Formula { get; set; } = string.Empty;
        public string ConditionalFormat { get; set; } = string.Empty;
        public bool IndicatorColumn { get; set; } = false;
  
    }
}
