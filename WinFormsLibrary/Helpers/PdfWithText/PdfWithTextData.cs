using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsLibrary.Helpers.PdfWithText
{
    public class PdfWithTextData
    {
        public string FilePath { get; set; } = string.Empty;
        public string DocumentTitle { get; set; } = string.Empty;
        public List<string>? Paragraphs { get; set; }        
    }
}
