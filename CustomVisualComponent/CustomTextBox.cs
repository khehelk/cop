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
        public CustomTextBox()
        {
            InitializeComponent();
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

        public string InputValue
        {
            get
            {
                if (string.IsNullOrEmpty(pattern)) return string.Empty;
                //throw new CustomPatternTextBoxException("Pattern is not set.");

                if (!Regex.IsMatch(textBox.Text, pattern)) return string.Empty;
                //throw new CustomPatternTextBoxException("Input value does not match the pattern.");

                return textBox.Text;
            }
            set
            {
                if (string.IsNullOrEmpty(pattern)) return;
                //throw new CustomPatternTextBoxException("Pattern is not set.");

                if (!Regex.IsMatch(value, pattern)) return;
                    //throw new CustomPatternTextBoxException("Input value does not match the pattern.");

                textBox.Text = value;
                OnValueChanged(EventArgs.Empty);
            }
        }

        public event EventHandler ValueChanged;

        protected virtual void OnValueChanged(EventArgs e)
        {
            ValueChanged?.Invoke(this, e);
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