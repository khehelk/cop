namespace UI
{
    partial class FormProvider
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
            labelProviderName = new Label();
            textBoxName = new TextBox();
            panelName = new Panel();
            panelFurniture = new Panel();
            textBoxFurniture = new TextBox();
            labelFurniture = new Label();
            panelType = new Panel();
            buttonTypeForm = new Button();
            customComboBoxType = new CustomComponentLibrary.CustomComboBox();
            labelType = new Label();
            panel1 = new Panel();
            controlInputNullableDate = new ControlsLibraryNet60.Input.ControlInputNullableDate();
            labelDate = new Label();
            buttonSave = new Button();
            panel2 = new Panel();
            buttonCancel = new Button();
            panelName.SuspendLayout();
            panelFurniture.SuspendLayout();
            panelType.SuspendLayout();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // labelProviderName
            // 
            labelProviderName.AutoSize = true;
            labelProviderName.Dock = DockStyle.Top;
            labelProviderName.Location = new Point(10, 10);
            labelProviderName.Name = "labelProviderName";
            labelProviderName.Size = new Size(59, 15);
            labelProviderName.TabIndex = 0;
            labelProviderName.Text = "Название";
            // 
            // textBoxName
            // 
            textBoxName.Dock = DockStyle.Top;
            textBoxName.Location = new Point(10, 25);
            textBoxName.Name = "textBoxName";
            textBoxName.Size = new Size(164, 23);
            textBoxName.TabIndex = 1;
            textBoxName.TextChanged += OnInputChange;
            // 
            // panelName
            // 
            panelName.AutoSize = true;
            panelName.Controls.Add(textBoxName);
            panelName.Controls.Add(labelProviderName);
            panelName.Dock = DockStyle.Top;
            panelName.Location = new Point(0, 0);
            panelName.Margin = new Padding(0);
            panelName.Name = "panelName";
            panelName.Padding = new Padding(10);
            panelName.Size = new Size(184, 58);
            panelName.TabIndex = 2;
            // 
            // panelFurniture
            // 
            panelFurniture.AutoSize = true;
            panelFurniture.Controls.Add(textBoxFurniture);
            panelFurniture.Controls.Add(labelFurniture);
            panelFurniture.Dock = DockStyle.Top;
            panelFurniture.Location = new Point(0, 58);
            panelFurniture.Margin = new Padding(0);
            panelFurniture.Name = "panelFurniture";
            panelFurniture.Padding = new Padding(10);
            panelFurniture.Size = new Size(184, 58);
            panelFurniture.TabIndex = 3;
            // 
            // textBoxFurniture
            // 
            textBoxFurniture.Dock = DockStyle.Top;
            textBoxFurniture.Location = new Point(10, 25);
            textBoxFurniture.Name = "textBoxFurniture";
            textBoxFurniture.Size = new Size(164, 23);
            textBoxFurniture.TabIndex = 1;
            textBoxFurniture.TextChanged += OnInputChange;
            // 
            // labelFurniture
            // 
            labelFurniture.AutoSize = true;
            labelFurniture.Dock = DockStyle.Top;
            labelFurniture.Location = new Point(10, 10);
            labelFurniture.Name = "labelFurniture";
            labelFurniture.Size = new Size(50, 15);
            labelFurniture.TabIndex = 0;
            labelFurniture.Text = "Мебель";
            // 
            // panelType
            // 
            panelType.AutoSize = true;
            panelType.Controls.Add(buttonTypeForm);
            panelType.Controls.Add(customComboBoxType);
            panelType.Controls.Add(labelType);
            panelType.Dock = DockStyle.Top;
            panelType.Location = new Point(0, 116);
            panelType.Margin = new Padding(0);
            panelType.Name = "panelType";
            panelType.Padding = new Padding(10);
            panelType.Size = new Size(184, 87);
            panelType.TabIndex = 4;
            // 
            // buttonTypeForm
            // 
            buttonTypeForm.Location = new Point(10, 51);
            buttonTypeForm.Name = "buttonTypeForm";
            buttonTypeForm.Size = new Size(164, 23);
            buttonTypeForm.TabIndex = 2;
            buttonTypeForm.Text = "Изменить список типов организаций";
            buttonTypeForm.UseVisualStyleBackColor = true;
            buttonTypeForm.Click += ButtonTypeForm_Click;
            // 
            // customComboBoxType
            // 
            customComboBoxType.Dock = DockStyle.Top;
            customComboBoxType.Location = new Point(10, 25);
            customComboBoxType.Margin = new Padding(0);
            customComboBoxType.Name = "customComboBoxType";
            customComboBoxType.SelectedValue = "";
            customComboBoxType.Size = new Size(164, 23);
            customComboBoxType.TabIndex = 1;
            // 
            // labelType
            // 
            labelType.AutoSize = true;
            labelType.Dock = DockStyle.Top;
            labelType.Location = new Point(10, 10);
            labelType.Name = "labelType";
            labelType.Size = new Size(101, 15);
            labelType.TabIndex = 0;
            labelType.Text = "Тип организации";
            // 
            // panel1
            // 
            panel1.AutoSize = true;
            panel1.Controls.Add(controlInputNullableDate);
            panel1.Controls.Add(labelDate);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 203);
            panel1.Margin = new Padding(0);
            panel1.Name = "panel1";
            panel1.Padding = new Padding(10);
            panel1.Size = new Size(184, 58);
            panel1.TabIndex = 6;
            // 
            // controlInputNullableDate
            // 
            controlInputNullableDate.Dock = DockStyle.Top;
            controlInputNullableDate.Location = new Point(10, 25);
            controlInputNullableDate.Margin = new Padding(4, 3, 4, 3);
            controlInputNullableDate.Name = "controlInputNullableDate";
            controlInputNullableDate.Size = new Size(164, 23);
            controlInputNullableDate.TabIndex = 1;
            controlInputNullableDate.Value = null;
            // 
            // labelDate
            // 
            labelDate.AutoSize = true;
            labelDate.Dock = DockStyle.Top;
            labelDate.Location = new Point(10, 10);
            labelDate.Name = "labelDate";
            labelDate.Size = new Size(85, 15);
            labelDate.TabIndex = 0;
            labelDate.Text = "Дата поставки";
            // 
            // buttonSave
            // 
            buttonSave.Location = new Point(14, 13);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(75, 23);
            buttonSave.TabIndex = 7;
            buttonSave.Text = "Сохранить";
            buttonSave.UseVisualStyleBackColor = true;
            buttonSave.Click += ButtonSave_Click;
            // 
            // panel2
            // 
            panel2.AutoSize = true;
            panel2.Controls.Add(buttonCancel);
            panel2.Controls.Add(buttonSave);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 261);
            panel2.Margin = new Padding(0);
            panel2.Name = "panel2";
            panel2.Padding = new Padding(10);
            panel2.Size = new Size(184, 49);
            panel2.TabIndex = 8;
            // 
            // buttonCancel
            // 
            buttonCancel.Location = new Point(95, 13);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(75, 23);
            buttonCancel.TabIndex = 8;
            buttonCancel.Text = "Отмена";
            buttonCancel.UseVisualStyleBackColor = true;
            buttonCancel.Click += ButtonCancel_Click;
            // 
            // FormProvider
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(184, 311);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(panelType);
            Controls.Add(panelFurniture);
            Controls.Add(panelName);
            MaximumSize = new Size(900, 350);
            MinimumSize = new Size(200, 350);
            Name = "FormProvider";
            Text = "Добавление/Редактирование";
            FormClosing += FormProvider_FormClosing;
            Load += FormProvider_Load;
            panelName.ResumeLayout(false);
            panelName.PerformLayout();
            panelFurniture.ResumeLayout(false);
            panelFurniture.PerformLayout();
            panelType.ResumeLayout(false);
            panelType.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelProviderName;
        private TextBox textBoxName;
        private Panel panelName;
        private Panel panelFurniture;
        private TextBox textBoxFurniture;
        private Label labelFurniture;
        private Panel panelType;
        private Label labelType;
        private CustomComponentLibrary.CustomComboBox customComboBoxType;
        private Panel panel1;
        private ControlsLibraryNet60.Input.ControlInputNullableDate controlInputNullableDate;
        private Label labelDate;
        private Button buttonSave;
        private Panel panel2;
        private Button buttonCancel;
        private Button buttonTypeForm;
    }
}