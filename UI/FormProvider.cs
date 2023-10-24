using Contracts.BindingModels;
using Contracts.SearchModels;
using Contracts.StoragesContracts;
using Contracts.ViewModels;
using DocumentFormat.OpenXml.VariantTypes;

namespace UI
{
    public partial class FormProvider : Form
    {
        private int? _id;
        public int Id { set { _id = value; } }
        public readonly IProviderStorage _providerStorage;
        public readonly ITypeStorage _typeStorage;
        private bool isEdited;

        public FormProvider(
            IProviderStorage providerStorage,
            ITypeStorage typeStorage
        )
        {
            _providerStorage = providerStorage;
            _typeStorage = typeStorage;
            isEdited = false;

            InitializeComponent();
        }

        private void FormProvider_Load(
            object sender,
            EventArgs e
        )
        {
            controlInputNullableDate.ElementChanged += OnInputChange;
            customComboBoxType.ExplicitEvent += OnInputChange;
            LoadData();
            if (_id.HasValue)
            {
                try
                {
                    var element = _providerStorage.GetElement(new ProviderSearchModel
                    {
                        Id = _id.Value,
                    });
                    if (element != null)
                    {
                        textBoxName.Text = element.Name;
                        textBoxFurniture.Text = element.Furniture;
                        customComboBoxType.SelectedValue = element.Type;
                        controlInputNullableDate.Value = element.SupplyDate;
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

        private void LoadData()
        {
            try
            {
                var list = _typeStorage.GetFullList();
                List<string> strings = new();
                foreach (var item in list)
                {
                    strings.Add(item.Name);
                }
                customComboBoxType.Clear();
                foreach (var item in strings)
                    customComboBoxType.AddToCustomComboBox.Add(item);
                if (_id.HasValue)
                {
                    var view = _providerStorage.GetElement(new ProviderSearchModel
                    {
                        Id = _id!.Value
                    });
                    customComboBoxType.SelectedValue = view!.Type;
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

        private void OnInputChange(
            object sender,
            EventArgs e
        )
        {
            isEdited = true;
        }

        private void ButtonSave_Click(
            object sender,
            EventArgs e
        )
        {
            if (string.IsNullOrEmpty(textBoxName.Text))
            {
                MessageBox.Show("Название не указано");
                return;
            }
            if (string.IsNullOrEmpty(textBoxFurniture.Text))
            {
                MessageBox.Show("Перечень мебели не указан");
                return;
            }
            if (string.IsNullOrEmpty(customComboBoxType.SelectedValue))
            {
                MessageBox.Show("Тип предприятия не выбран");
                return;
            }
            isEdited = false;
            try
            {
                var model = new ProviderBindingModel
                {
                    Id = _id ?? 0,
                    Name = textBoxName.Text,
                    Furniture = textBoxFurniture.Text,
                    Type = customComboBoxType.SelectedValue,
                    SupplyDate = (controlInputNullableDate.Value != null) ?
                        DateTime.SpecifyKind((DateTime)controlInputNullableDate.Value, DateTimeKind.Utc)
                        : controlInputNullableDate.Value,
                };
                var action = _id.HasValue ? _providerStorage.Update(model) : _providerStorage.Insert(model);
                DialogResult = DialogResult.OK;
                Close();
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

        private void ButtonCancel_Click(
            object sender,
            EventArgs e
        )
        {
            Close();
        }

        private void ButtonTypeForm_Click(
            object sender,
            EventArgs e
        )
        {
            var service = Program.ServiceProvider?.GetService(typeof(FormType));
            if (service is FormType form)
            {
                form.ShowDialog();
                LoadData();
            }
        }

        private void FormProvider_FormClosing(
            object sender,
            FormClosingEventArgs e
        )
        {
            if (!isEdited) return;
            var confirmResult = MessageBox.Show(
                "Имеются незафиксированные изменения." +
                "\n" +
                "Вы действительно хотите закрыть форму?",
                "Подтвердите действие",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );
            if (confirmResult == DialogResult.No) e.Cancel = true;
        }
    }
}
