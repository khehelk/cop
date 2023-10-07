using iText.IO.Image;
using iText.Kernel.Font;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Legends;
using OxyPlot.Series;
using OxyPlot.WindowsForms;
using System.ComponentModel;
using System.Net.Http.Headers;
using System.Reflection;

namespace CustomComponent
{
    public partial class ComponentWithLinearDiagram : Component
    {
        public ComponentWithLinearDiagram()
        {
            InitializeComponent();
        }

        public ComponentWithLinearDiagram(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }        

        public void GeneratePdfDocumentWithChart(
            PdfDiagramFileInfo pdfInfo,
            DiagramData diagInfo
        ){
            PdfFont font = PdfFontFactory.CreateFont("c:\\windows\\fonts\\times.ttf", "Identity-H");

            if (pdfInfo == null || 
                pdfInfo.FileName == null || 
                pdfInfo.DocumentTitle == null ||
                diagInfo == null || 
                diagInfo.DiagramName == null ||
                diagInfo.Series == null ||
                diagInfo.LegendPosition == null)
            {
                return;
            }

            // Create a new OxyPlot chart
            var plotModel = new PlotModel { Title = diagInfo.DiagramName };

            // Add X and Y axes
            var xAxis = new LinearAxis { Position = AxisPosition.Bottom };
            var yAxis = new LinearAxis { Position = AxisPosition.Left };
            plotModel.Axes.Add(xAxis);
            plotModel.Axes.Add(yAxis);

            // Create a series for the data
            foreach(var item in diagInfo.Series)
            {
                var singleSeries = new LineSeries { Title = item.Key };
                foreach(var coordinates in item.Value)
                {
                    singleSeries.Points.Add(new DataPoint(coordinates.Item1, coordinates.Item2));
                }
                plotModel.Series.Add(singleSeries);
            }

            var fieldInfo = typeof(DiagramLegendPosition).GetField(diagInfo.LegendPosition.ToString());
            var attribute = fieldInfo.GetCustomAttribute<LegendSettingsAttribute>();

            plotModel.Legends.Add(new Legend(){
                LegendTitle = "Legend",
                LegendPlacement = attribute.Placement,
                LegendPosition = attribute.Position,
            });
            plotModel.IsLegendVisible = true;            

            // Create a PDF document
            using (var pdfDocument = new PdfDocument(new PdfWriter(pdfInfo.FileName)))
            {
                var document = new Document(pdfDocument);
                document.SetFont(font);

                Paragraph title = new Paragraph(pdfInfo.DocumentTitle)
                            .SetFont(font)
                            .SetFontSize(18)
                            .SetBold()
                            .SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER);
                ;
                document.Add(title);

                // Create an image of the chart using OxyPlot
                var chartImage = new MemoryStream();
                var exporter = new PngExporter { Width = 600, Height = 450 };
                exporter.Export(plotModel, chartImage);

                // Insert the image into the PDF
                var image = new iText.Layout.Element.Image(ImageDataFactory.Create(chartImage.ToArray()));
                document.Add(image);

                // Close the PDF document
                document.Close();            
            }
        }
    }    

    public class PdfDiagramFileInfo
    {
        public string? FileName { get; set; }
        public string? DocumentTitle { get; set; }
    }

    public class DiagramData
    {
        public string? DiagramName { get; set; }
        public DiagramLegendPosition LegendPosition { get; set; }
        public Dictionary<string, List<(double, double)>>? Series { get; set; }
    }
}
