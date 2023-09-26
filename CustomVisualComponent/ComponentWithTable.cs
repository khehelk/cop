using PdfSharp.Pdf;
using PdfSharp.Drawing;
using MigraDoc.DocumentObjectModel;
using MigraDoc.DocumentObjectModel.Tables;
using MigraDoc.Rendering;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.ComponentModel;
using System.Text;
using System.Reflection;

namespace CustomVisualComponent
{
    public partial class ComponentWithTable : Component
    {
        public ComponentWithTable()
        {
            InitializeComponent();
        }

        public ComponentWithTable(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        public void GeneratePdfDocument(
            string filePath,
            string documentTitle,
            List<(int, int)> merged_cells,
            List<int> cells_width,
            List<ColumnHeader> headers,
            List<ColumnData> data)
        {
            /*// Проверка на заполненность входных данных
            if (string.IsNullOrWhiteSpace(filePath) || string.IsNullOrWhiteSpace(documentTitle) || columns == null || columns.Count == 0 || data == null || data.Count == 0)
            {
                throw new ArgumentException("Не все входные данные были предоставлены.");
            }*/
            Document document = new Document();
            Section section = document.AddSection();

            section.AddParagraph(documentTitle);

            Table table = section.AddTable();
            table.Borders.Width = 0.75;

            for (int i = 0; i < 4; i++)
            {
                Column column = table.AddColumn();
                column.Width = Unit.FromCentimeter(cells_width[i]);
            }

            //Создание заголовков
            Row upperHeaderRow = table.AddRow();
            Row lowerHeaderRow = table.AddRow();
            foreach(var cell in merged_cells)
            {
                upperHeaderRow.Cells[cell.Item1].MergeRight = cell.Item2 - cell.Item1;
            }

            int headerIndex = 0;
            foreach(var header in headers)
            {
                upperHeaderRow.Cells[headerIndex].AddParagraph(header.content);
                if (header.subHeaders?.Count > 0)
                {                    
                    int subheaderIndex = 0;
                    foreach(var subheader in header.subHeaders)
                    {
                        lowerHeaderRow.Cells[headerIndex + subheaderIndex].AddParagraph(subheader);
                        subheaderIndex++;
                    }
                }
                else {
                    upperHeaderRow.Cells[headerIndex].MergeDown = 1;
                }
                headerIndex++;
            }

            // Рендеринг MigraDoc-документа в PDF
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            PdfDocumentRenderer pdfRenderer = new PdfDocumentRenderer();
            pdfRenderer.Document = document;
            pdfRenderer.RenderDocument();

            // Сохранение PDF-файла
            pdfRenderer.PdfDocument.Save(filePath);
        }
    }

    public class ColumnHeader
    {
        public string? content;
        public List<string>? subHeaders;
    }

    public class ColumnData
    {
    }
}
