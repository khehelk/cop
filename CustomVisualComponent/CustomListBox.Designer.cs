namespace CustomVisualComponent
{
    partial class CustomListBox
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
            listBox = new ListBox();
            label = new Label();
            SuspendLayout();
            // 
            // listBox
            // 
            listBox.FormattingEnabled = true;
            listBox.ItemHeight = 15;
            listBox.Location = new Point(215, 15);
            listBox.Name = "listBox";
            listBox.Size = new Size(240, 79);
            listBox.TabIndex = 0;
            // 
            // label
            // 
            label.AutoSize = true;
            label.Location = new Point(3, 24);
            label.Name = "label";
            label.Size = new Size(207, 60);
            label.TabIndex = 2;
            label.Text = "Список значений. \r\nСписок заполняется через метод, \r\nпередающий объект, номер строки \r\nи имя свойства/поля";
            // 
            // CustomListBox
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(label);
            Controls.Add(listBox);
            Name = "CustomListBox";
            Size = new Size(471, 110);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox listBox;
        private Label label1;
        private Label label;
    }
}
