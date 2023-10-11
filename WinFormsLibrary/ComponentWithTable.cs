using iText.Kernel.Font;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinFormsLibrary.Helpers.PdfWithTable;

namespace WinFormsLibrary
{
    public partial class ComponentWithTable : Component
    {
        private PdfFont font;
        private int fontSize;

        public ComponentWithTable()
        {
            InitializeComponent();
        }

        public void GeneratePdf<T>(
            PdfWithTableData<T> pdfTable
        )
        {
            font = PdfFontFactory.CreateFont("c:\\windows\\fonts\\times.ttf", "Identity-H");
            fontSize = 14;

            if (pdfTable == null 
                || string.IsNullOrEmpty(pdfTable.FilePath) 
                || string.IsNullOrEmpty(pdfTable.DocumentTitle) 
                || pdfTable.TableHeader == null)
            {
                throw new ArgumentException("Недостаточно данных для создания PDF-документа.");
            }

            using (PdfWriter writer = new PdfWriter(pdfTable.FilePath))
            {
                using (PdfDocument pdf = new PdfDocument(writer))
                {
                    using (Document doc = new Document(pdf))
                    {
                        doc.SetFont(font)
                            .SetFontSize(fontSize);
                        Table table = new Table(GetColumnsNumber(pdfTable.TableHeader));

                        CreateTableHeader(table, pdfTable.TableHeader);

                        CreateTableData(table, pdfTable);

                        doc.Add(new Paragraph(pdfTable.DocumentTitle)
                            .SetBold()
                            .SetTextAlignment(TextAlignment.CENTER));
                        doc.Add(table);
                        doc.Close();
                    }
                }                
            }            
        }

        public int GetColumnsNumber(List<PdfWithTableHeader> headers)
        {
            int columnsNumber = 0;
            foreach (var headerCell in headers)
            {
                if (headerCell.SubColumns.Count > 0)
                {
                    columnsNumber+=headerCell.SubColumns.Count;
                    continue;
                }
                columnsNumber++;
            }
            return columnsNumber;
        }

        public void CreateTableHeader(Table table, List<PdfWithTableHeader> headerInfo)
        {
            foreach (var column in headerInfo)
            {
                Cell headerCell = new Cell(
                        column.SubColumns.Count == 0 ? 2 : 1, 
                        column.MergeEnd - column.MergeStart + 1 ?? 1
                    )
                   .SetWidth(column.ColumnWidth)
                   .SetTextAlignment(TextAlignment.CENTER)
                   .Add(new Paragraph(column.ColumnName).SetFont(font).SetFontSize(fontSize).SetBold());

                table.AddHeaderCell(headerCell);
                if (column.SubColumns.Count > 0)
                {
                    CreateTableSubHeader(table, column.SubColumns);
                }
            }
        }

        public void CreateTableSubHeader(Table table, List<PdfWithTableSubHeader> subHeaderInfo)
        {
            foreach (var column in subHeaderInfo)
            {
                Cell headerCell = new Cell()
                   .SetWidth(column.ColumnWidth)
                   .SetTextAlignment(TextAlignment.CENTER)
                   .Add(new Paragraph(column.ColumnName)
                            .SetFont(font)
                            .SetFontSize(fontSize)
                            .SetBold());

                table.AddHeaderCell(headerCell);
            }
        }

        private void CreateTableData<T>(Table table, PdfWithTableData<T> data)
        {
            if (data == null || data.TableData == null) return;
            for(int i = 0; i < data.TableData.Count; ++i)
            {
                foreach (var column in data.Props)
                {
                    try
                    {
                        string cellValue = typeof(T).GetProperty(column).GetValue(data.TableData[i], null).ToString();
                        table.AddCell(new Paragraph(cellValue).SetFont(font).SetFontSize(fontSize));
                    }
                    catch { }                                       
                }
            }
        }        

        public ComponentWithTable(IContainer container)
        {
            container.Add(this);
            InitializeComponent();
        }
    }
}