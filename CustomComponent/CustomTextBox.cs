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
using System.Windows.Forms.VisualStyles;

namespace CustomComponent
{
    public partial class CustomTextBox : UserControl
    {
        public event EventHandler ValueChanged;

        public CustomTextBox()
        {
            InitializeComponent();
            Error = string.Empty;
            textBox.TextChanged += (sender, e) =>
            {
                OnValueChanged(EventArgs.Empty);
            };
        }

        protected virtual void OnValueChanged(EventArgs e)
        {
            EventHandler handler = ValueChanged;
            handler?.Invoke(this, e);
        }

        private string pattern;
        private string example;

        public string Pattern
        {
            get { return pattern; }
            set
            {
                pattern = value;
                UpdateText();
            }
        }

        public string Example
        {
            set
            {
                example = value;
                toolTip.SetToolTip(this, example);
            }
        }

        public string Error
        {
            get;
            private set;
        }

        public string InputValue
        {
            get
            {
                if (string.IsNullOrEmpty(pattern))
                {
                    Error = "Не задан шаблон!";
                    return string.Empty;
                }

                //throw new CustomPatternTextBoxException("Pattern is not set.");

                if (!Regex.IsMatch(textBox.Text, pattern))
                {
                    Error = "Введенные данные не удовлетворяют шаблону!";
                    return string.Empty;
                }

                //throw new CustomPatternTextBoxException("Input value does not match the pattern.");

                return textBox.Text;
            }
            set
            {
                if (string.IsNullOrEmpty(pattern))
                {
                    Error = "Не задан шаблон!";
                    return;
                }
                //throw new CustomPatternTextBoxException("Pattern is not set.");

                if (!Regex.IsMatch(value, pattern))
                {
                    Error = "Введенные данные не удовлетворяют шаблону!";
                    return;
                }

                //throw new CustomPatternTextBoxException("Input value does not match the pattern.");

                textBox.Text = value;
                OnValueChanged(EventArgs.Empty);
            }
        }

        public event EventHandler CustomValueChanged
        {
            add
            {
                textBox.TextChanged += value;
            }
            remove
            {
                textBox.TextChanged -= value;
            }
        }

        private void UpdateText()
        {
            if (string.IsNullOrEmpty(pattern) || !Regex.IsMatch(textBox.Text, pattern))
            {
                textBox.Text = "";
            }
        }
    }

    public class CustomPatternTextBoxException : Exception
    {
        public CustomPatternTextBoxException(string message) : base(message) { }
    }
}