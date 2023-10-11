namespace CustomComponentLibrary
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
            SuspendLayout();
            // 
            // comboBox
            // 
            comboBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            comboBox.FormattingEnabled = true;
            comboBox.Location = new Point(15, 13);
            comboBox.Name = "comboBox";
            comboBox.Size = new Size(174, 23);
            comboBox.TabIndex = 0;
            comboBox.SelectedIndexChanged += ComboBox_SelectedValueChanged;
            // 
            // CustomComboBox
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(comboBox);
            Name = "CustomComboBox";
            Size = new Size(201, 50);
            ResumeLayout(false);
        }

        #endregion

        private ComboBox comboBox;
    }
}
