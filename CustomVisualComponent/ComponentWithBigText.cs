using System;
using System.Collections.Generic;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using System.IO;
using System.ComponentModel;
using iText.Kernel.Font;
using System.Text;

namespace CustomVisualComponent
{
    public partial class ComponentWithBigText : Component
    {
        public ComponentWithBigText()
        {
            InitializeComponent();
        }

        public void GeneratePdfDocument(PdfDocumentData documentData)
        {
            if (string.IsNullOrEmpty(documentData.FilePath) ||
            string.IsNullOrEmpty(documentData.DocumentTitle) ||
            documentData.Paragraphs == null || documentData.Paragraphs.Count == 0)
            {
                throw new ArgumentException("Недостаточно данных для создания PDF-документа.");
            }
            using (PdfWriter writer = new PdfWriter(new FileInfo(documentData.FilePath)))
            {
                using (PdfDocument pdf = new PdfDocument(writer))
                {
                    using (Document doc = new Document(pdf))
                    {
                        PdfFont font = PdfFontFactory.CreateFont("c:\\windows\\fonts\\times.ttf", "Identity-H");

                        // Добавление заголовка
                        Paragraph title = new Paragraph(documentData.DocumentTitle)
                            .SetFont(font)
                            .SetFontSize(18)
                            .SetBold()
                            .SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER);
                        ;
                        doc.Add(title);

                        // Добавление текста из массива строк
                        foreach (string text in documentData.Paragraphs)
                        {
                            Paragraph paragraph = new Paragraph(text)
                                .SetFont(font)
                                .SetFontSize(12);
                            doc.Add(paragraph);
                        }
                        doc.Close();
                    }
                }
            }
        }
    }            

    public class PdfDocumentData
    {
        public string FilePath { get; set; }
        public string DocumentTitle { get; set; }
        public List<string> Paragraphs { get; set; }
    }
}
