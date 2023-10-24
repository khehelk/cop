using ComponentsLibraryNet60.Core;
using ComponentsLibraryNet60.Models;
using Contracts.StoragesContracts;
using Contracts.ViewModels;
using ControlsLibraryNet60.Models;
using DatabaseImplement.Implements;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using WinFormsLibrary;
using WinFormsLibrary.Helpers.PdfWithText;
using static iText.Kernel.Pdf.Tagging.PdfUserProperty;
using static Org.BouncyCastle.Math.EC.ECCurve;

namespace UI
{
    public partial class FormMain : Form
    {
        private readonly IProviderStorage _providerStorage;
        private readonly ITypeStorage _typeStorage;

        public FormMain(
            IProviderStorage providerStorage,
            ITypeStorage typeStorage
        )
        {
            _providerStorage = providerStorage;
            _typeStorage = typeStorage;

            InitializeComponent();
            KeyDown += new KeyEventHandler(FormMain_KeyDown);
        }

        private void FormMain_Load(
            object sender,
            EventArgs e
        )
        {
            LoadData();

        }

        private void LoadData()
        {
            try
            {
                var providers = _providerStorage.GetFullList();
                if (providers != null)
                {
                    controlDataTreeCell.Clear();
                    TreeColumnConfiguration();
                    if (providers.Count > 0) AddTreeData(providers);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void TreeColumnConfiguration()
        {
            DataTreeNodeConfig treeConfig = new();
            treeConfig.NodeNames = new();
            treeConfig.NodeNames.Enqueue("Type");
            treeConfig.NodeNames.Enqueue("SupplyDateTime");
            treeConfig.NodeNames.Enqueue("Id");
            treeConfig.NodeNames.Enqueue("Name");

            controlDataTreeCell.LoadConfig(treeConfig);
        }

        private void AddTreeData(List<ProviderViewModel> providers)
        {
            int numOfProperties = typeof(ProviderViewModel).GetProperties().Length;
            for (int i = 0; i < providers.Count; ++i)
            {
                providers[i].SupplyDateTime = providers[i].SupplyDate.ToString();
                for (int j = 0; j < numOfProperties; ++j)
                {
                    controlDataTreeCell.AddCell(j, providers[i]);
                }
            }
        }

        private void AddProviderItem_Click(
            object sender,
            EventArgs e
        )
        {
            var service = Program.ServiceProvider?.GetService(typeof(FormProvider));
            if (service is FormProvider form)
            {
                form.ShowDialog();
                LoadData();
            }
        }

        private void EditProviderItem_Click(
            object sender,
            EventArgs e
        )
        {
            if (controlDataTreeCell.GetSelectedObject<ProviderViewModel>() == null)
            {
                return;
            }
            else
            {
                var service = Program.ServiceProvider?.GetService(typeof(FormProvider));
                if (service is FormProvider form)
                {
                    form.Id = Convert.ToInt32(controlDataTreeCell.GetSelectedObject<ProviderViewModel>()?.Id);
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        LoadData();
                    }
                }
            }
        }

        private void RemoveProviderItem_Click(
            object sender,
            EventArgs e
        )
        {
            if (controlDataTreeCell.GetSelectedObject<ProviderViewModel>() == null) return;
            if (MessageBox.Show(
                "Вы хотите удалить выбранный элементы?",
                "Вопрос",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.Yes)
            {
                _providerStorage.Delete(new(controlDataTreeCell.GetSelectedObject<ProviderViewModel>()));
                LoadData();
            }
        }

        private void GetSimpleDocumentItem_Click(
            object sender,
            EventArgs e
        )
        {
            PdfWithTextData pdfWithTextData = new();

            SaveFileDialog saveFileDialog = new()
            {
                Filter = "PDF Files|*.pdf"
            };
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                pdfWithTextData.FilePath = saveFileDialog.FileName;
                pdfWithTextData.DocumentTitle = "Поставщики";
                pdfWithTextData.Paragraphs = new();

                foreach (var provider in _providerStorage.GetFullList())
                {
                    pdfWithTextData.Paragraphs.Add(provider.Name + ": " + provider.Furniture);
                }

                try
                {
                    componentWithText.GeneratePdfDocument(pdfWithTextData);
                    MessageBox.Show(
                        "PDF-документ успешно сохранен.",
                        "Успех",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        $"Ошибка при создании PDF-документа: {ex.Message}",
                        "Ошибка",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                }
            }
        }

        private void GetTableDocumentItem_Click(
            object sender,
            EventArgs e
        )
        {
            List<ProviderViewModel> providersList = _providerStorage.GetFullList();
            foreach (var provider in providersList)
            {
                if (provider.SupplyDate == null)
                {
                    provider.SupplyDateTime = "Поставок не было";
                    provider.SupplyDate = DateTime.MinValue;
                    continue;
                }
                provider.SupplyDateTime = provider.SupplyDate.ToString();
            }

            ComponentDocumentWithTableHeaderDataConfig<ProviderViewModel> config = new()
            {
                Data = providersList,
                Headers = new()
                {
                    (0, 0, "Идентификатор", "Id"),
                    (1, 0, "Название", "Name"),
                    (2, 0, "Тип организации", "Type"),
                    (3, 0, "Дата поставки", "SupplyDateTime"),
                },
                Header = "Отчет по всем поставщикам",
                UseUnion = false,
                ColumnsRowsWidth = new()
                {
                    (10,10),
                    (10,10),
                    (10,10),
                    (10,10),
                },
                ColumnsRowsDataCount = new()
            };

            SaveFileDialog saveFileDialog = new()
            {
                Filter = "Excel Files|*.xlsx"
            };
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                config.FilePath = saveFileDialog.FileName;

                try
                {

                    componentDocumentWithTableMultiHeaderExcel.CreateDoc(config);
                    MessageBox.Show(
                        "Excel-документ успешно сохранен.",
                        "Успех",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        $"Ошибка при создании Excel-документа: {ex.Message}",
                        "Ошибка",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                }
            }
        }

        private void GetDiagramDocumentItem_Click(
            object sender,
            EventArgs e
        )
        {
            var providersList = _providerStorage
                .GetFullList()
                .Where(item => item.SupplyDate?.Year == DateTime.Now.Year)
                .GroupBy(item => item.Type)
                .Select(group => new
                {
                    Type = group.Key,
                    Date = group.Select(item => item.SupplyDate),
                    Count = (double)group.Count(),
                });

            var resultData = new Dictionary<string, List<(int, double)>>();

            foreach (var provider in providersList)
            {
                resultData[provider.Type] = new() { (DateTime.Now.Year, provider.Count) };
            }

            ComponentDocumentWithChartConfig config = new()
            {
                ChartTitle = "Количество поставщиков в разрезе типа организации",
                LegendLocation = ComponentsLibraryNet60.Models.Location.Bottom,
                Header = "Круговая диаграмма",
                Data = new()
                {
                    {"Типы организаций", new(){(2023, 25.0), (2023, 12.0), (2023, 37.0)} },
                },
            };

            SaveFileDialog saveFileDialog = new()
            {
                Filter = "Word Files|*.docx"
            };
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                config.FilePath = saveFileDialog.FileName;
                try
                {
                    componentDocumentWithChartPieWord.CreateDoc(config);
                    MessageBox.Show(
                        "Word-документ успешно сохранен.",
                        "Успех",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        $"Ошибка при создании Word-документа: {ex.Message}",
                        "Ошибка",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                }
            }
        }

        private void FormMain_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control)
            {
                switch (e.KeyCode)
                {
                    case Keys.A:
                        AddProviderItem_Click(sender, e);
                        break;
                    case Keys.U:
                        EditProviderItem_Click(sender, e);
                        break;
                    case Keys.D:
                        RemoveProviderItem_Click(sender, e);
                        break;
                    case Keys.S:
                        GetSimpleDocumentItem_Click(sender, e);
                        break;
                    case Keys.T:
                        GetTableDocumentItem_Click(sender, e);
                        break;
                    case Keys.C:
                        GetDiagramDocumentItem_Click(sender, e);
                        break;
                }
            }
        }
    }
}
