namespace CustomVisualComponent
{
    partial class CustomTextBox
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            label = new Label();
            textBox = new TextBox();
            toolTip = new ToolTip(components);
            SuspendLayout();
            // 
            // label
            // 
            label.AutoSize = true;
            label.Location = new Point(3, 0);
            label.Name = "label";
            label.Size = new Size(196, 45);
            label.TabIndex = 3;
            label.Text = "Поле для ввода номера телефона \r\n(номер телефона должен \r\nсоответствовать шаблону)";
            // 
            // textBox
            // 
            textBox.Location = new Point(219, 11);
            textBox.Name = "textBox";
            textBox.Size = new Size(168, 23);
            textBox.TabIndex = 2;
            // 
            // CustomTextBox
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(label);
            Controls.Add(textBox);
            Name = "CustomTextBox";
            Size = new Size(423, 48);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label;
        private TextBox textBox;
        private ToolTip toolTip;
    }
}
