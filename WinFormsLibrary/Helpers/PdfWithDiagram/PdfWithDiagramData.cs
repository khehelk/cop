using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsLibrary.Helpers.PdfWithDiagram
{
    public class PdfWithDiagramData
    {
        public string FilePath { get; set; } = string.Empty;
        public string DocumentTitle { get; set; } = string.Empty;
        public string DiagramName { get; set; } = string.Empty;
        public DiagramLegendPosition LegendPosition { get; set; } = DiagramLegendPosition.BottomCenterOutside;
        public List<PdfWithDiagramSeries> Series { get; set; } = new();
    }
}
