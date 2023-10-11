using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CustomComponentLibrary
{
    public partial class CustomComboBox : UserControl
    {
        public CustomComboBox()
        {
            InitializeComponent();
        }

        //Очистка
        public void Clear()
        {
            comboBox.Items.Clear();
        }

        //Для заполнения
        public ComboBox.ObjectCollection AddToCustomComboBox
        {
            get { return comboBox.Items; }
        }

        public string SelectedValue
        {
            get
            {
                if (comboBox.SelectedItem != null)
                {
                    return comboBox.SelectedItem.ToString() ?? "";
                }
                return string.Empty;
            }
            set
            {
                if (comboBox.Items.Contains(value))
                {
                    comboBox.SelectedItem = value;
                }
            }
        }

        private EventHandler _explicitEvent;
        public event EventHandler ExplicitEvent
        {
            add
            {
                _explicitEvent += value;
            }
            remove
            {
                _explicitEvent -= value;
            }
        }

        private void ComboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            _explicitEvent?.Invoke(sender, e);
        }
    }
}
