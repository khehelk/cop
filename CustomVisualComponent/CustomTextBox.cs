using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CustomVisualComponent
{
    public partial class CustomTextBox : UserControl
    {
        private string pattern = @"^(?:\+7|8)\s\d{3}\s\d{3}\s\d{2}\s\d{2}$"; // Шаблон для номера телефона

        public CustomTextBox()
        {
            InitializeComponent();
        }


        [Category("Custom")]
        public string Value
        {
            get { return textBox.Text; }
            set
            {
                textBox.Text = value;
                ValidateInput(value);
            }
        }

        public event EventHandler ValueChanged;

        private void TextBox_TextChanged(object sender, EventArgs e)
        {
            ValidateInput(textBox.Text);
            ValueChanged?.Invoke(this, EventArgs.Empty);
        }

        private void ValidateInput(string input)
        {
            if (!Regex.IsMatch(input, pattern))
            {
                toolTip.Show("Некорректный формат номера телефона: (+7/8 XXX XXX XX XX)", textBox, 0, -30, 2000);
                textBox.BackColor = System.Drawing.Color.LightSalmon;
            }
            else
            {
                textBox.BackColor = System.Drawing.SystemColors.Window;
            }
        }
    }
}
