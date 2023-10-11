using CustomComponentLibrary;
using PdfSharp.Drawing;
using PdfSharp.Drawing.Layout;
using PdfSharp.Pdf;
using MigraDoc.Rendering;
using System.Text;
using System.Windows.Forms;
using MigraDoc.DocumentObjectModel.Tables;
using System.Runtime.CompilerServices;
using MigraDoc.DocumentObjectModel;
using WinFormsLibrary.Helpers.PdfWithText;
using WinFormsLibrary.Helpers.PdfWithTable;
using WinFormsLibrary.Helpers.PdfWithDiagram;

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
            string documentTitle = textBoxHeader.Text;
            string[] paragraphs = textBoxParagraphs.Lines;

            if (string.IsNullOrWhiteSpace(documentTitle) || paragraphs.Length == 0)
            {
                MessageBox.Show("Заголовок и абзацы не могут быть пустыми.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "PDF Files|*.pdf";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = saveFileDialog.FileName;

                PdfWithTextData pdfData = new PdfWithTextData
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
            PdfWithTableData<TestData> tableData = new();
            List<PdfWithTableHeader> tableHeader = new()
            {
                new PdfWithTableHeader()
                {
                    ColumnName="Id", 
                    ColumnWidth=50
                },
                new PdfWithTableHeader()
                {
                    ColumnName="University", 
                    ColumnWidth=100
                },
                new PdfWithTableHeader()
                {
                    ColumnName="PersonalData",
                    ColumnWidth=350,
                    MergeStart=2,
                    MergeEnd=3,
                    SubColumns = new()
                    {
                        new (){ ColumnName="Name", ColumnWidth=175},
                        new (){ ColumnName="City", ColumnWidth=175}
                    }
                }
            };            

            tableData.TableHeader = tableHeader;
            tableData.Props = new List<string> { "Id", "University", "Name", "City" };
            tableData.TableData = new()
            {
                new TestData(1, "УлГТУ", "Николай", "Ульяновск"),
                new TestData(2, "УлГУ", "Иван", "Ульяновск"),
            };            

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "PDF Files|*.pdf";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = saveFileDialog.FileName;

                tableData.DocumentTitle = textBoxHeader.Text;
                tableData.FilePath = filePath;

                try
                {
                    componentWithTable.GeneratePdf(tableData);
                    MessageBox.Show("PDF-документ успешно сохранен.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при создании PDF-документа: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void buttonDiagram_Click(object sender, EventArgs e)
        {
            PdfWithDiagramData diagramData = new();

            diagramData.DocumentTitle = textBoxHeader.Text;
            diagramData.DiagramName = textBoxHeader.Text;
            diagramData.LegendPosition = DiagramLegendPosition.BottomCenterOutside;
            diagramData.Series = new(){
                new()
                {
                    Name = "Ряд 1",
                    Data = new List<(double, double)>()
                    {
                        (1, 1),
                        (5, 10),
                        (10, 7),
                        (15, 12),
                        (20, 35),
                    }
                },
                new()
                {
                    Name = "Ряд 2",
                    Data = new List<(double, double)>()
                    {
                        (1, 7),
                        (5, 12),
                        (10, 35),
                        (15, 1),
                        (20, 10),
                    }
                }
            };                                    

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "PDF Files|*.pdf";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = saveFileDialog.FileName;
                diagramData.FilePath = filePath;                

                try
                {
                    componentWithLinearDiagram.GeneratePdfDocumentWithChart(diagramData);
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
