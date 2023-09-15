namespace CustomVisualComponent
{
    partial class CustomTextBox
    {
        /// <summary> 
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            textBox = new TextBox();
            label = new Label();
            toolTip = new ToolTip(components);
            SuspendLayout();
            // 
            // textBox
            // 
            textBox.Location = new Point(219, 13);
            textBox.Name = "textBox";
            textBox.Size = new Size(168, 23);
            textBox.TabIndex = 0;
            textBox.TextChanged += TextBox_TextChanged;
            // 
            // label
            // 
            label.AutoSize = true;
            label.Location = new Point(3, 2);
            label.Name = "label";
            label.Size = new Size(196, 45);
            label.TabIndex = 1;
            label.Text = "Поле для ввода номера телефона \r\n(номер телефона должен \r\nсоответствовать шаблону)";
            // 
            // CustomTextBox
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(label);
            Controls.Add(textBox);
            Name = "CustomTextBox";
            Size = new Size(400, 50);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox;
        private Label label;
        private ToolTip toolTip;
    }
}
