using PdfSharp.Drawing;
using PdfSharp.Drawing.Layout;
using PdfSharp.Pdf;
using MigraDoc.DocumentObjectModel;
using MigraDoc.Rendering;
using System.ComponentModel;
using System.Text;

namespace CustomVisualComponent
{
    public partial class ComponentWithBigText : Component
    {
        public ComponentWithBigText()
        {
            InitializeComponent();            
        }

        public ComponentWithBigText(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        private void DefineStyles(Document document)
        {
            var style = document.Styles["Normal"];
            style.Font.Name = "Times New Roman";
            style.Font.Size = 14;

            style = document.Styles.AddStyle("NormalTitle", "Normal");
            style.Font.Bold = true;
        }

        public void GeneratePdfDocument(PdfDocumentData data)
        {
            // Проверка на заполненность входных данных
            if (string.IsNullOrWhiteSpace(data.FilePath) ||
                string.IsNullOrWhiteSpace(data.DocumentTitle) ||
                data.Paragraphs == null || data.Paragraphs.Count == 0)
            {
                throw new ArgumentException("Не все входные данные были предоставлены.");
            }

            // Создание нового PDF-документа
            PdfDocument pdfDocument = new PdfDocument();

            // Добавление новой страницы
            pdfDocument.AddPage();

            // Создание MigraDoc-документа
            Document document = new Document();
            DefineStyles(document);
            Section section = document.AddSection();
            section.PageSetup.PageFormat = PageFormat.A4;

            // Добавление заголовка
            Style boldStyle = document.Styles.AddStyle("BoldStyle", "Normal");
            boldStyle.Font.Bold = true;
            Paragraph title = section.AddParagraph(data.DocumentTitle);
            title.Format.Alignment = ParagraphAlignment.Center;
            title.Style = "BoldStyle";

            // Добавление абзацев
            foreach (string paragraphText in data.Paragraphs)
            {
                Paragraph paragraph = section.AddParagraph(paragraphText);
                paragraph.Format.SpaceAfter = "1cm";
            }

            // Рендеринг MigraDoc-документа в PDF
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            PdfDocumentRenderer pdfRenderer = new PdfDocumentRenderer(true)
            {
                Document = document
            };
            pdfRenderer.RenderDocument();

            // Сохранение PDF-файла
            // Регистрация провайдера кодировки для кодировки 1252, без этого ошибОчка была
            pdfRenderer.PdfDocument.Save(data.FilePath);
        }
    }

    public class PdfDocumentData
    {
        public string FilePath { get; set; }
        public string DocumentTitle { get; set; }
        public List<string> Paragraphs { get; set; }
    }
}
