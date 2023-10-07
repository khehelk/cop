﻿using iText.Kernel.Font;
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

namespace CustomComponent
{
    public partial class ComponentWithTable : Component
    {
        private PdfFont font;
        private int fontSize;

        public ComponentWithTable()
        {
            InitializeComponent();
        }

        public void GeneratePdf(
            PdfTableData docInfo,
            List<HeaderInfo> headers,
            TableData data
        )
        {
            font = PdfFontFactory.CreateFont("c:\\windows\\fonts\\times.ttf", "Identity-H");
            fontSize = 14;

            if (docInfo == null || string.IsNullOrEmpty(docInfo.FileName) || string.IsNullOrEmpty(docInfo.DocumentTitle) ||
                headers == null || headers.Count == 0)
            {
                throw new ArgumentException("Недостаточно данных для создания PDF-документа.");
            }

            using (PdfWriter writer = new PdfWriter(docInfo.FileName))
            using (PdfDocument pdf = new PdfDocument(writer))
            using (Document doc = new Document(pdf))
            {
                // Создание таблицы
                Table table = new Table(GetColumnsNumber(headers));

                // Создание строки заголовка
                CreateTableHeader(table, headers);

                // Добавление данных
                CreateTableData(table, data, headers);

                // Добавление таблицы в документ
                doc.Add(new Paragraph(docInfo.DocumentTitle).SetFont(font).SetFontSize(fontSize).SetBold().SetTextAlignment(TextAlignment.CENTER));
                doc.Add(table);
                doc.Close();
            }
        }

        public int GetColumnsNumber(List<HeaderInfo> headers)
        {
            int columnsNumber = 0;
            foreach (var headerCell in headers)
            {
                if (headerCell.SubColumns.Count > 0)
                {
                    foreach (var item in headerCell.SubColumns)
                    {
                        columnsNumber++;
                    }
                    continue;
                }
                columnsNumber++;
            }
            return columnsNumber;
        }

        private void CreateTableData(Table table, TableData data, List<HeaderInfo> headers)
        {
            if (data == null || data.Data == null) return;
            foreach (var item in data.Data)
            {
                foreach (var column in headers)
                {
                    if (column.SubColumns.Count > 0)
                    {
                        TableData td = new();
                        td.Data = new();
                        td.Data.Add(item);
                        CreateTableData(table, td, column.SubColumns);
                    }
                    else
                    {
                        string cellValue = item.ContainsKey(column.ColumnName) ? item[column.ColumnName] : string.Empty;
                        table.AddCell(new Paragraph(cellValue).SetFont(font).SetFontSize(fontSize));
                    }
                }
            }
        }

        public void CreateTableHeader(Table table, List<HeaderInfo> headerInfo)
        {
            foreach (var column in headerInfo)
            {
                Cell headerCell = new Cell((column.IsSubColumn == false && column.SubColumns.Count == 0) ? 2 : 1, column.MergeEnd - column.MergeStart + 1 ?? 1)
                   .SetWidth(column.ColumnWidth)
                   .SetTextAlignment(TextAlignment.CENTER)
                   .Add(new Paragraph(column.ColumnName).SetFont(font).SetFontSize(fontSize).SetBold());

                table.AddHeaderCell(headerCell);                
                if (column.SubColumns.Count > 0)
                {
                    CreateTableHeader(table, column.SubColumns);
                }
            }
        }

        public ComponentWithTable(IContainer container)
        {
            container.Add(this);
            InitializeComponent();
        }
    }

    public class PdfTableData
    {
        public string? FileName { get; set; }
        public string? DocumentTitle { get; set; }
    }

    public class HeaderInfo
    {
        public string? ColumnName { get; set; } = string.Empty;
        public int ColumnWidth { get; set; } = 100;
        public int? MergeStart { get; set; } // Начальная строка объединения
        public int? MergeEnd { get; set; }
        public bool IsSubColumn { get; set; } = false;
        public List<HeaderInfo> SubColumns { get; set; } = new List<HeaderInfo>();
    }

    public class TableData
    {
        public List<Dictionary<string, string>>? Data { get; set; }
    }
}