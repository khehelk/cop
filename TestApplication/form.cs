using CustomComponent;
using PdfSharp.Drawing;
using PdfSharp.Drawing.Layout;
using PdfSharp.Pdf;
using MigraDoc.Rendering;
using System.Text;
using System.Windows.Forms;
using MigraDoc.DocumentObjectModel.Tables;
using System.Runtime.CompilerServices;

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
            DocumentInfo documentInfo = new DocumentInfo();
            
            List<HeaderInfo> headerInfos = new()
            {
                new (){ColumnName="ID", ColumnWidth=50, RowSpan=2, ColumnSpan=1},
                new (){ColumnName="University", ColumnWidth=100, RowSpan=2, ColumnSpan=1},
                new (){
                    ColumnName="PersonalData", 
                    ColumnWidth=300,
                    RowSpan=1,
                    ColumnSpan=3,
                    SubColumns = new()
                    {
                        new (){ ColumnName="Name", ColumnWidth=100, RowSpan=1, ColumnSpan=1},
                        new (){ ColumnName="Surname", ColumnWidth=100, RowSpan=1, ColumnSpan=1},
                        new (){ ColumnName="City", ColumnWidth=100, RowSpan=1, ColumnSpan=1}
                    }
                },
            };

            TableData data = new();
            data.Data =
                new()
                {
                    new Dictionary<string, string>
                {
                    { "ID", "1" },
                    { "University", "УлГТУ" },
                    { "Name", "Иван" },
                    { "Surname", "Петров" },
                    { "City", "Ульяновск" },
                },
                new Dictionary<string, string>
                {
                    { "ID", "2" },
                    { "University", "УлГУ" },
                    { "Name", "Иван" },
                    { "Surname", "Петров" },
                    { "City", "Ульяновск" },
                },
                // Добавьте другие записи
            };

            // Определите путь к сохранению PDF-файла
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "PDF Files|*.pdf";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = saveFileDialog.FileName;

                documentInfo.DocumentTitle = textBoxHeader.Text;
                documentInfo.FileName = filePath;

                try
                {
                    componentWithTable.GeneratePdf(documentInfo, headerInfos, data);
                    MessageBox.Show("PDF-документ успешно сохранен.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при создании PDF-документа: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
