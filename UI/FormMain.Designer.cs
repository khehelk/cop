namespace UI
{
    partial class FormMain
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
            controlDataTableCell1 = new ControlsLibraryNet60.Data.ControlDataTableCell();
            SuspendLayout();
            // 
            // controlDataTableCell1
            // 
            controlDataTableCell1.Dock = DockStyle.Fill;
            controlDataTableCell1.Location = new Point(0, 0);
            controlDataTableCell1.Margin = new Padding(4, 3, 4, 3);
            controlDataTableCell1.Name = "controlDataTableCell1";
            controlDataTableCell1.SelectedRowIndex = -1;
            controlDataTableCell1.Size = new Size(800, 450);
            controlDataTableCell1.TabIndex = 0;
            // 
            // FormMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(controlDataTableCell1);
            Name = "FormMain";
            Text = "Основная форма";
            Load += FormMain_Load;
            ResumeLayout(false);
        }

        #endregion

        private ControlsLibraryNet60.Data.ControlDataTableCell controlDataTableCell1;
    }
}