namespace CustomComponent
{
    partial class CustomComboBox
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
            comboBox = new ComboBox();
            label = new Label();
            SuspendLayout();
            // 
            // comboBox
            // 
            comboBox.FormattingEnabled = true;
            comboBox.Location = new Point(179, 13);
            comboBox.Name = "comboBox";
            comboBox.Size = new Size(174, 23);
            comboBox.TabIndex = 0;
            comboBox.SelectedIndexChanged += ComboBox_SelectedValueChanged;
            // 
            // label
            // 
            label.AutoSize = true;
            label.Location = new Point(3, 2);
            label.Name = "label";
            label.Size = new Size(156, 45);
            label.TabIndex = 1;
            label.Text = "Выпадающий список. \r\nСписок заполняется через \r\nпубличное свойство";
            // 
            // CustomComboBox
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(label);
            Controls.Add(comboBox);
            Name = "CustomComboBox";
            Size = new Size(365, 50);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox comboBox;
        private Label label;
    }
}
