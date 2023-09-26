using CustomVisualComponent;
using PdfSharp.Drawing;
using PdfSharp.Drawing.Layout;
using PdfSharp.Pdf;
using MigraDoc.DocumentObjectModel;
using MigraDoc.Rendering;
using System.Text;
using System.Windows.Forms;
using MigraDoc.DocumentObjectModel.Tables;

namespace TestApplication
{
    public partial class form : Form
    {
        public form()
        {
            InitializeComponent();
        }

        private void buttonSaveFirst_Click(object sender, EventArgs e)
        {
            // Получаем введенный заголовок и текст абзацев
            string documentTitle = textBoxHeader.Text;
            string[] paragraphs = textBoxParagraphs.Lines;

            if (string.IsNullOrWhiteSpace(documentTitle) || paragraphs.Length == 0)
            {
                MessageBox.Show("Заголовок и абзацы не могут быть пустыми.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Определите путь к сохранению PDF-файла
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "PDF Files|*.pdf";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = saveFileDialog.FileName;

                // Создаем объект PdfDocumentData
                PdfDocumentData pdfData = new PdfDocumentData
                {
                    FilePath = filePath,
                    DocumentTitle = documentTitle,
                    Paragraphs = new List<string>(paragraphs)
                };

                try
                {
                    componentWithBigText.GeneratePdfDocument(pdfData);
                    MessageBox.Show("PDF-документ успешно сохранен.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при создании PDF-документа: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void buttonSaveSecond_Click(object sender, EventArgs e)
        {
            // Создайте экземпляр PdfTableGenerator и вызовите метод для создания PDF-документа
            List<CustomVisualComponent.ColumnHeader> columnHeaders = new List<CustomVisualComponent.ColumnHeader>();

            CustomVisualComponent.ColumnHeader columnHeaderId = new CustomVisualComponent.ColumnHeader();
            columnHeaderId.content = "ID";
            CustomVisualComponent.ColumnHeader columnHeaderSpecs = new CustomVisualComponent.ColumnHeader();
            columnHeaderSpecs.content = "Характеристики";
            columnHeaderSpecs.subHeaders = new List<string>() { "Вес", "Цвет", "Высота" };

            columnHeaders.Add(columnHeaderId);
            columnHeaders.Add(columnHeaderSpecs);

            componentWithTable.GeneratePdfDocument(
                "example.pdf",
                "Таблица с группировкой",
                new List<(int, int)>{(1, 3)},
                new List<int>(){50,50,50,50},
                columnHeaders,
                new List<ColumnData>());

            // Определите путь к сохранению PDF-файла
            /*
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "PDF Files|*.pdf";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = saveFileDialog.FileName;

                try
                {
                    componentWithTable.GeneratePdfTableDocument(filePath, documentTitle, columns, data);
                    MessageBox.Show("PDF-документ успешно сохранен.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при создании PDF-документа: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            componentWithTable.GeneratePdfTableDocument(filePath, documentTitle, new List<TableColumnGroup> { columnGroup1, columnGroup2 }, data);*/

                
        }
    }
}
