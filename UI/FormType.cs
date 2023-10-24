using Contracts.BindingModels;
using Contracts.SearchModels;
using Contracts.StoragesContracts;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI
{
    public partial class FormType : Form
    {
        private readonly ITypeStorage _typeStorage;

        public FormType(ITypeStorage typeStorage)
        {
            _typeStorage = typeStorage;

            InitializeComponent();
        }

        private void FormType_Load(
            object sender, 
            EventArgs e
        ){
            LoadData();
        }

        public void LoadData()
        {
            try
            {
                var types = _typeStorage.GetFullList();
                if (types != null)
                {
                    dataGridView.DataSource = types;
                    dataGridView.Columns["Id"].Visible = false;
                    dataGridView.Columns["Name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dataGridView.Columns["Name"].Tag = "Название";
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

        private void DataGridView_KeyDown(
            object sender, 
            KeyEventArgs e
        ){
            switch (e.KeyCode)
            {
                case Keys.Insert:
                    AddType();
                    e.Handled = true;
                    break;
                case Keys.Delete:
                    RemoveType();
                    e.Handled = true;
                    break;
                
            }
        }

        private void AddType()
        {
            var list = _typeStorage.GetFullList();
            list.Add(new());
            if (list != null)
            {
                dataGridView.DataSource = list;
                dataGridView.Columns["Id"].Visible = false;
                dataGridView.Columns["Name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }            
        }

        private void RemoveType()
        {
            if (dataGridView.SelectedRows.Count > 0)
            {
                DialogResult result = MessageBox.Show(
                    "Вы уверены, что хотите удалить выбранные записи?",
                    "Подтверждение удаления", 
                    MessageBoxButtons.YesNo, 
                    MessageBoxIcon.Question
                );
                if (result == DialogResult.Yes)
                {
                    foreach (DataGridViewRow row in dataGridView.SelectedRows)
                    {
                        if (!row.IsNewRow)
                        {
                            int id = Convert.ToInt32(row.Cells["Id"].Value);
                            var view = _typeStorage.GetElement(new TypeSearchModel
                            {
                                Id = id
                            });
                            _typeStorage.Delete(new(view!));
                        }
                    }
                    LoadData();
                }
            }
        }

        private void DataGridView_CellValueChanged(
            object sender,
            DataGridViewCellEventArgs e
        ){
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView.Rows[e.RowIndex];
                int id = Convert.ToInt32(row.Cells["Id"].Value);
                string? name = row.Cells["Name"].Value?.ToString();

                if (string.IsNullOrWhiteSpace(name))
                {
                    MessageBox.Show(
                        "Нельзя сохранить запись с пустым именем!",
                        "Ошибка",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                    LoadData();
                }
                else
                {
                    var model = new TypeBindingModel
                    {
                        Id = id,
                        Name = name
                    };
                    if (model.Id == 0) _typeStorage.Insert(model);
                    else _typeStorage.Update(model);
                    LoadData();
                }
            }
        }
    }
}
