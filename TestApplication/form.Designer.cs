namespace TestApplication
{
    partial class form
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            textBoxHeader = new TextBox();
            labelHeader = new Label();
            labelText = new Label();
            textBoxParagraphs = new TextBox();
            buttonSaveFirst = new Button();
            buttonSaveSecond = new Button();
            componentWithBigText = new WinFormsLibrary.ComponentWithText();
            componentWithTable = new WinFormsLibrary.ComponentWithTable(components);
            buttonDiagram = new Button();
            componentWithLinearDiagram = new WinFormsLibrary.ComponentWithLinearDiagram(components);
            SuspendLayout();
            // 
            // textBoxHeader
            // 
            textBoxHeader.Location = new Point(83, 12);
            textBoxHeader.Name = "textBoxHeader";
            textBoxHeader.Size = new Size(184, 23);
            textBoxHeader.TabIndex = 0;
            // 
            // labelHeader
            // 
            labelHeader.AutoSize = true;
            labelHeader.Location = new Point(12, 15);
            labelHeader.Name = "labelHeader";
            labelHeader.Size = new Size(65, 15);
            labelHeader.TabIndex = 1;
            labelHeader.Text = "Заголовок";
            // 
            // labelText
            // 
            labelText.AutoSize = true;
            labelText.Location = new Point(12, 47);
            labelText.Name = "labelText";
            labelText.Size = new Size(39, 15);
            labelText.TabIndex = 2;
            labelText.Text = "Текст:";
            // 
            // textBoxParagraphs
            // 
            textBoxParagraphs.Location = new Point(83, 47);
            textBoxParagraphs.Multiline = true;
            textBoxParagraphs.Name = "textBoxParagraphs";
            textBoxParagraphs.Size = new Size(184, 107);
            textBoxParagraphs.TabIndex = 3;
            // 
            // buttonSaveFirst
            // 
            buttonSaveFirst.Location = new Point(284, 80);
            buttonSaveFirst.Name = "buttonSaveFirst";
            buttonSaveFirst.Size = new Size(100, 74);
            buttonSaveFirst.TabIndex = 4;
            buttonSaveFirst.Text = "Сохранить первый pdf";
            buttonSaveFirst.UseVisualStyleBackColor = true;
            buttonSaveFirst.Click += buttonSaveFirst_Click;
            // 
            // buttonSaveSecond
            // 
            buttonSaveSecond.Location = new Point(390, 80);
            buttonSaveSecond.Name = "buttonSaveSecond";
            buttonSaveSecond.Size = new Size(100, 74);
            buttonSaveSecond.TabIndex = 5;
            buttonSaveSecond.Text = "Получить таблицу";
            buttonSaveSecond.UseVisualStyleBackColor = true;
            buttonSaveSecond.Click += buttonSaveSecond_Click;
            // 
            // buttonDiagram
            // 
            buttonDiagram.Location = new Point(496, 80);
            buttonDiagram.Name = "buttonDiagram";
            buttonDiagram.Size = new Size(100, 74);
            buttonDiagram.TabIndex = 6;
            buttonDiagram.Text = "Получить диаграмму";
            buttonDiagram.UseVisualStyleBackColor = true;
            buttonDiagram.Click += buttonDiagram_Click;
            // 
            // form
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 697);
            Controls.Add(buttonDiagram);
            Controls.Add(buttonSaveSecond);
            Controls.Add(buttonSaveFirst);
            Controls.Add(textBoxParagraphs);
            Controls.Add(labelText);
            Controls.Add(labelHeader);
            Controls.Add(textBoxHeader);
            Name = "form";
            Text = "form";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox textBoxHeader;
        private Label labelHeader;
        private Label labelText;
        private TextBox textBoxParagraphs;
        private Button buttonSaveFirst;
        private Button buttonSaveSecond;
        private WinFormsLibrary.ComponentWithText componentWithBigText;
        private WinFormsLibrary.ComponentWithTable componentWithTable;
        private Button buttonDiagram;
        private WinFormsLibrary.ComponentWithLinearDiagram componentWithLinearDiagram;
    }
}