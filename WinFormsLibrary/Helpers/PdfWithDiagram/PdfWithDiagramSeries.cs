using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsLibrary.Helpers.PdfWithDiagram
{
    public class PdfWithDiagramSeries
    {
        public string Name { get; set; } = string.Empty;
        public List<(double, double)> Data { get; set; } = new();
    }
}
