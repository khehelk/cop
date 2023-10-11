using System;
using System.Collections.Generic;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using System.IO;
using System.ComponentModel;
using iText.Kernel.Font;
using System.Text;
using WinFormsLibrary.Helpers.PdfWithText;

namespace WinFormsLibrary
{
    public partial class ComponentWithText : Component
    {
        public ComponentWithText()
        {
            InitializeComponent();
        }

        public void GeneratePdfDocument(PdfWithTextData pdfText)
        {
            PdfFont font = PdfFontFactory.CreateFont("c:\\windows\\fonts\\times.ttf", "Identity-H");

            if (string.IsNullOrEmpty(pdfText.FilePath) 
                || string.IsNullOrEmpty(pdfText.DocumentTitle) 
                || pdfText.Paragraphs == null)
            {
                throw new ArgumentException("Недостаточно данных для создания PDF-документа.");
            }
            using (PdfWriter writer = new PdfWriter(new FileInfo(pdfText.FilePath)))
            {
                using (PdfDocument pdf = new PdfDocument(writer))
                {
                    using (Document doc = new Document(pdf))
                    {
                        doc.SetFont(font)
                           .SetFontSize(18);

                        Paragraph title = new Paragraph(pdfText.DocumentTitle)                            
                            .SetBold()
                            .SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER);
                        ;
                        doc.Add(title);

                        foreach (string text in pdfText.Paragraphs)
                        {
                            Paragraph paragraph = new Paragraph(text)
                                .SetFontSize(12);
                            doc.Add(paragraph);
                        }
                        doc.Close();
                    }
                }
            }
        }
    }      
}
