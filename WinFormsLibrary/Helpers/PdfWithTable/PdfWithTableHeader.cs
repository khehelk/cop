using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsLibrary.Helpers.PdfWithTable
{
    public class PdfWithTableHeader
    {
        public string? ColumnName { get; set; } = string.Empty;
        public int ColumnWidth { get; set; } = 100;
        public int? MergeStart { get; set; } // Начальная колонка объединения
        public int? MergeEnd { get; set; }
        public List<PdfWithTableSubHeader> SubColumns { get; set; } = new List<PdfWithTableSubHeader>();
    }

    public class PdfWithTableSubHeader
    {
        public string? ColumnName { get; set; } = string.Empty;
        public int ColumnWidth { get; set; } = 100;
    }
}
