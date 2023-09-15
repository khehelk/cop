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
            customTextBox1 = new CustomVisualComponent.CustomTextBox();
            SuspendLayout();
            // 
            // customComboBox1
            // 
            customComboBox1.Items = (List<string>)resources.GetObject("customComboBox1.Items");
            customComboBox1.Location = new Point(12, 12);
            customComboBox1.Name = "customComboBox1";
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
            // customTextBox1
            // 
            customTextBox1.Location = new Point(12, 68);
            customTextBox1.Name = "customTextBox1";
            customTextBox1.Size = new Size(400, 50);
            customTextBox1.TabIndex = 2;
            customTextBox1.Value = "";
            // 
            // form
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(customTextBox1);
            Controls.Add(customListBox1);
            Controls.Add(customComboBox1);
            Name = "form";
            Text = "form";
            ResumeLayout(false);
        }

        #endregion

        private CustomVisualComponent.CustomComboBox customComboBox1;
        private CustomVisualComponent.CustomListBox customListBox1;
        private CustomVisualComponent.CustomTextBox customTextBox1;
    }
}