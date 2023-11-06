using Contracts.ViewModels;
using ControlsLibraryNet60.Data;
using PluginsConventionLibrary;
using WinFormsLibrary.Helpers.PdfWithText;
using WinFormsLibrary;
using ComponentsLibraryNet60.DocumentWithTable;
using ComponentsLibraryNet60.Models;
using Contracts.StoragesContracts;
using ComponentsLibraryNet60.DocumentWithChart;
using DatabaseImplement.Implements;
using ControlsLibraryNet60.Models;

namespace UI
{
    public class PluginsConvention : IPluginsConvention
    {
        private readonly IProviderStorage _providerStorage;
        private readonly ITypeStorage _typeStorage;
        private readonly ControlDataTreeCell _controlDataTreeCell;        
        private readonly ComponentWithText _componentWithText;
        private readonly ComponentDocumentWithTableMultiHeaderExcel _componentDocumentWithTableMultiHeaderExcel;
        private readonly ComponentDocumentWithChartPieWord _componentDocumentWithChartPieWord;
        public string PluginName { get; set; } = "lab3";

        public PluginsConvention()
        {
            _providerStorage = new ProviderStorage();
            _typeStorage = new TypeStorage();
            _componentWithText = new();
            _componentDocumentWithTableMultiHeaderExcel = new();
            _componentDocumentWithChartPieWord = new();
            _controlDataTreeCell = new();
        }

        public UserControl GetControl
        {
            get { return _controlDataTreeCell; }
        }

        public PluginsConventionElement GetElement
        {
            get
            {
                int Id = _controlDataTreeCell.GetSelectedObject<ProviderViewModel>()!.Id;
                byte[] bytes = new byte[16];
                BitConverter.GetBytes(Id).CopyTo(bytes, 0);
                Guid guid = new Guid(bytes);
                return new PluginsConventionElement() { Id = guid };
            }
        }

        public bool CreateChartDocument(PluginsConventionSaveDocument saveDocument)
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

            var resultData = new List<(int, double)>();

            foreach (var provider in providersList)
            {
                resultData.Add((DateTime.Now.Year, provider.Count));
            }

            ComponentDocumentWithChartConfig config = new()
            {
                ChartTitle = "Количество поставщиков в разрезе типа организации",
                LegendLocation = ComponentsLibraryNet60.Models.Location.Bottom,
                Header = "Круговая диаграмма",
                Data = new()
                {
                    { "Тип организации", resultData },
                },
                FilePath = saveDocument.FileName
            };
                
            try
            {
                _componentDocumentWithChartPieWord.CreateDoc(config);
                MessageBox.Show(
                    "Word-документ успешно сохранен.",
                    "Успех",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Ошибка при создании Word-документа: {ex.Message}",
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                return false;
            }            
        }

        public bool CreateSimpleDocument(PluginsConventionSaveDocument saveDocument)
        {
            PdfWithTextData pdfWithTextData = new()
            {
                FilePath = saveDocument.FileName,
                DocumentTitle = "Поставщики",
                Paragraphs = new()
            };

            foreach (var provider in _providerStorage.GetFullList())
            {
                pdfWithTextData.Paragraphs.Add(provider.Name + ": " + provider.Furniture);
            }

            try
            {
                _componentWithText.GeneratePdfDocument(pdfWithTextData);
                MessageBox.Show(
                    "PDF-документ успешно сохранен.",
                    "Успех",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Ошибка при создании PDF-документа: {ex.Message}",
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                return false;
            }
        }

        public bool CreateTableDocument(PluginsConventionSaveDocument saveDocument)
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
                ColumnsRowsDataCount = new(),
                FilePath = saveDocument.FileName
            };

            try
            {
                _componentDocumentWithTableMultiHeaderExcel.CreateDoc(config);
                MessageBox.Show(
                    "Excel-документ успешно сохранен.",
                    "Успех",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Ошибка при создании Excel-документа: {ex.Message}",
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                return false;
            }
            
        }

        public bool DeleteElement(PluginsConventionElement element)
        {
            _providerStorage.Delete(
                new(element.Id.GetHashCode())
            );
            return true;
        }

        public Form GetForm(PluginsConventionElement element)
        {
            if (element == null)
            {
                return new FormProvider(_providerStorage, _typeStorage);
            }
            else
            {
                FormProvider form = new FormProvider(_providerStorage, _typeStorage);
                form.Id = element.Id.GetHashCode();
                return form;
            }
        }

        public Form GetThesaurus()
        {
            return new FormType(_typeStorage);
        }

        public void ReloadData()
        {
            try
            {
                var providers = _providerStorage.GetFullList();
                if (providers != null)
                {
                    _controlDataTreeCell.Clear();

                    DataTreeNodeConfig treeConfig = new();
                    treeConfig.NodeNames = new();
                    treeConfig.NodeNames.Enqueue("Type");
                    treeConfig.NodeNames.Enqueue("SupplyDateTime");
                    treeConfig.NodeNames.Enqueue("Id");
                    treeConfig.NodeNames.Enqueue("Name");
                    _controlDataTreeCell.LoadConfig(treeConfig);                   

                    if (providers.Count > 0)
                    {
                        int numOfProperties = typeof(ProviderViewModel).GetProperties().Length;
                        for (int i = 0; i < providers.Count; ++i)
                        {
                            providers[i].SupplyDateTime = providers[i].SupplyDate.ToString();
                            for (int j = 0; j < numOfProperties; ++j)
                            {
                                _controlDataTreeCell.AddCell(j, providers[i]);
                            }
                        }
                    }
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
    }
}
