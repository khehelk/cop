using iText.IO.Image;
using iText.Kernel.Font;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using Org.BouncyCastle.Math.EC.Multiplier;
using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Legends;
using OxyPlot.Series;
using OxyPlot.WindowsForms;
using System.ComponentModel;
using System.Net.Http.Headers;
using System.Reflection;
using WinFormsLibrary.Helpers.PdfWithDiagram;

namespace WinFormsLibrary
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
            PdfWithDiagramData pdfDiagram
        ){
            PdfFont font = PdfFontFactory.CreateFont("c:\\windows\\fonts\\times.ttf", "Identity-H");

            if (string.IsNullOrEmpty(pdfDiagram.FilePath) 
                || string.IsNullOrEmpty(pdfDiagram.DocumentTitle) 
                || string.IsNullOrEmpty(pdfDiagram.DiagramName) 
                || pdfDiagram.Series == null)
            {
                return;
            }

            var plotModel = new PlotModel { Title = pdfDiagram.DiagramName };

            var xAxis = new LinearAxis { Position = AxisPosition.Bottom };
            var yAxis = new LinearAxis { Position = AxisPosition.Left };
            plotModel.Axes.Add(xAxis);
            plotModel.Axes.Add(yAxis);

            foreach(var item in pdfDiagram.Series)
            {
                var singleSeries = new LineSeries { Title = item.Name };
                foreach(var coordinates in item.Data)
                {
                    singleSeries.Points.Add(new DataPoint(coordinates.Item1, coordinates.Item2));
                }
                plotModel.Series.Add(singleSeries);
            }

            var fieldInfo = typeof(DiagramLegendPosition).GetField(pdfDiagram.LegendPosition.ToString());
            var attribute = fieldInfo?.GetCustomAttribute<LegendSettingsAttribute>();

            plotModel.Legends.Add(new Legend(){
                LegendTitle = "Легенда",
                LegendPlacement = attribute.Placement,
                LegendPosition = attribute.Position,
            });
            plotModel.IsLegendVisible = true;            

            using (var pdfDocument = new PdfDocument(new PdfWriter(pdfDiagram.FilePath)))
            {
                var document = new Document(pdfDocument);
                document.SetFont(font)
                        .SetFontSize(18);

                Paragraph title = new Paragraph(pdfDiagram.DocumentTitle)                            
                            .SetBold()
                            .SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER);
                ;
                document.Add(title);

                var chartImage = new MemoryStream();
                var exporter = new PngExporter { Width = 600, Height = 450 };
                exporter.Export(plotModel, chartImage);

                var image = new iText.Layout.Element.Image(ImageDataFactory.Create(chartImage.ToArray()));
                document.Add(image);

                document.Close();            
            }
        }
    }    
}
