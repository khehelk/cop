using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsLibrary.Helpers.PdfWithTable
{
    public class PdfWithTableData<T>
    {
        public string FilePath { get; set; } = string.Empty;
        public string DocumentTitle { get; set; } = string.Empty;
        public List<PdfWithTableHeader> TableHeader { get; set; } = new();
        public List<T> TableData { get; set; } = new();
        public List<string> Props { get; set; } = new();
    }
}
