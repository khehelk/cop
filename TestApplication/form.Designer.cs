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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(form));
            customComboBox1 = new CustomVisualComponent.CustomComboBox();
            customListBox1 = new CustomVisualComponent.CustomListBox();
            label1 = new Label();
            buttonCheckTextBox = new Button();
            customTextBox1 = new CustomVisualComponent.CustomTextBox();
            buttonFillComboBox = new Button();
            buttonClearComboBox = new Button();
            buttonGetObj = new Button();
            labelObjFromStr = new Label();
            SuspendLayout();
            // 
            // customComboBox1
            // 
            customComboBox1.Items = (List<string>)resources.GetObject("customComboBox1.Items");
            customComboBox1.Location = new Point(12, 12);
            customComboBox1.Name = "customComboBox1";
            customComboBox1.SelectedValue = "";
            customComboBox1.Size = new Size(365, 50);
            customComboBox1.TabIndex = 0;
            // 
            // customListBox1
            // 
            customListBox1.Location = new Point(12, 124);
            customListBox1.Name = "customListBox1";
            customListBox1.Size = new Size(471, 110);
            customListBox1.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(522, 99);
            label1.Name = "label1";
            label1.Size = new Size(105, 15);
            label1.TabIndex = 3;
            label1.Text = "Проверка TextBox";
            // 
            // buttonCheckTextBox
            // 
            buttonCheckTextBox.Location = new Point(441, 95);
            buttonCheckTextBox.Name = "buttonCheckTextBox";
            buttonCheckTextBox.Size = new Size(75, 23);
            buttonCheckTextBox.TabIndex = 4;
            buttonCheckTextBox.Text = "Проверить";
            buttonCheckTextBox.UseVisualStyleBackColor = true;
            buttonCheckTextBox.Click += buttonCheckTextBox_Click;
            // 
            // customTextBox1
            // 
            customTextBox1.InputValue = "";
            customTextBox1.Location = new Point(12, 81);
            customTextBox1.Name = "customTextBox1";
            customTextBox1.Pattern = null;
            customTextBox1.Size = new Size(423, 48);
            customTextBox1.TabIndex = 5;
            // 
            // buttonFillComboBox
            // 
            buttonFillComboBox.Location = new Point(441, 26);
            buttonFillComboBox.Name = "buttonFillComboBox";
            buttonFillComboBox.Size = new Size(129, 23);
            buttonFillComboBox.TabIndex = 6;
            buttonFillComboBox.Text = "Заполнить список";
            buttonFillComboBox.UseVisualStyleBackColor = true;
            buttonFillComboBox.Click += buttonFillComboBox_Click;
            // 
            // buttonClearComboBox
            // 
            buttonClearComboBox.Location = new Point(576, 26);
            buttonClearComboBox.Name = "buttonClearComboBox";
            buttonClearComboBox.Size = new Size(75, 23);
            buttonClearComboBox.TabIndex = 7;
            buttonClearComboBox.Text = "Очистить";
            buttonClearComboBox.UseVisualStyleBackColor = true;
            buttonClearComboBox.Click += buttonClearComboBox_Click;
            // 
            // buttonGetObj
            // 
            buttonGetObj.Location = new Point(473, 154);
            buttonGetObj.Name = "buttonGetObj";
            buttonGetObj.Size = new Size(75, 23);
            buttonGetObj.TabIndex = 8;
            buttonGetObj.Text = "Получить объект";
            buttonGetObj.UseVisualStyleBackColor = true;
            buttonGetObj.Click += buttonGetObj_Click;
            // 
            // labelObjFromStr
            // 
            labelObjFromStr.AutoSize = true;
            labelObjFromStr.Location = new Point(576, 162);
            labelObjFromStr.Name = "labelObjFromStr";
            labelObjFromStr.Size = new Size(17, 15);
            labelObjFromStr.TabIndex = 9;
            labelObjFromStr.Text = "--";
            // 
            // form
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(labelObjFromStr);
            Controls.Add(buttonGetObj);
            Controls.Add(buttonClearComboBox);
            Controls.Add(buttonFillComboBox);
            Controls.Add(customTextBox1);
            Controls.Add(buttonCheckTextBox);
            Controls.Add(label1);
            Controls.Add(customListBox1);
            Controls.Add(customComboBox1);
            Name = "form";
            Text = "form";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private CustomVisualComponent.CustomComboBox customComboBox1;
        private CustomVisualComponent.CustomListBox customListBox1;
        private Label label1;
        private Button buttonCheckTextBox;
        private CustomVisualComponent.CustomTextBox customTextBox1;
        private Button buttonFillComboBox;
        private Button buttonClearComboBox;
        private Button buttonGetObj;
        private Label labelObjFromStr;
    }
}