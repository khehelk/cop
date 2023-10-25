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
            components = new System.ComponentModel.Container();
            contextMenuStrip = new ContextMenuStrip(components);
            addProviderItem = new ToolStripMenuItem();
            editProviderItem = new ToolStripMenuItem();
            removeProviderItem = new ToolStripMenuItem();
            getSimpleDocumentItem = new ToolStripMenuItem();
            getTableDocumentItem = new ToolStripMenuItem();
            getDiagramDocumentItem = new ToolStripMenuItem();
            открытьСправочникToolStripMenuItem = new ToolStripMenuItem();
            controlDataTreeCell = new ControlsLibraryNet60.Data.ControlDataTreeCell();
            componentWithText = new WinFormsLibrary.ComponentWithText();
            componentDocumentWithTableMultiHeaderExcel = new ComponentsLibraryNet60.DocumentWithTable.ComponentDocumentWithTableMultiHeaderExcel(components);
            componentDocumentWithChartPieWord = new ComponentsLibraryNet60.DocumentWithChart.ComponentDocumentWithChartPieWord(components);
            componentDocumentWithChartBarWord1 = new ComponentsLibraryNet60.DocumentWithChart.ComponentDocumentWithChartBarWord(components);
            contextMenuStrip.SuspendLayout();
            SuspendLayout();
            // 
            // contextMenuStrip
            // 
            contextMenuStrip.Items.AddRange(new ToolStripItem[] { addProviderItem, editProviderItem, removeProviderItem, getSimpleDocumentItem, getTableDocumentItem, getDiagramDocumentItem, открытьСправочникToolStripMenuItem });
            contextMenuStrip.Name = "contextMenuStrip1";
            contextMenuStrip.Size = new Size(265, 180);
            contextMenuStrip.Text = "Меню";
            // 
            // addProviderItem
            // 
            addProviderItem.DisplayStyle = ToolStripItemDisplayStyle.Text;
            addProviderItem.Name = "addProviderItem";
            addProviderItem.Size = new Size(264, 22);
            addProviderItem.Text = "Добавить";
            addProviderItem.Click += AddProviderItem_Click;
            // 
            // editProviderItem
            // 
            editProviderItem.Name = "editProviderItem";
            editProviderItem.Size = new Size(264, 22);
            editProviderItem.Text = "Редактировать";
            editProviderItem.Click += EditProviderItem_Click;
            // 
            // removeProviderItem
            // 
            removeProviderItem.Name = "removeProviderItem";
            removeProviderItem.Size = new Size(264, 22);
            removeProviderItem.Text = "Удалить";
            removeProviderItem.Click += RemoveProviderItem_Click;
            // 
            // getSimpleDocumentItem
            // 
            getSimpleDocumentItem.Name = "getSimpleDocumentItem";
            getSimpleDocumentItem.Size = new Size(264, 22);
            getSimpleDocumentItem.Text = "Получить простой документ";
            getSimpleDocumentItem.Click += GetSimpleDocumentItem_Click;
            // 
            // getTableDocumentItem
            // 
            getTableDocumentItem.Name = "getTableDocumentItem";
            getTableDocumentItem.Size = new Size(264, 22);
            getTableDocumentItem.Text = "Получить документ с таблицей";
            getTableDocumentItem.Click += GetTableDocumentItem_Click;
            // 
            // getDiagramDocumentItem
            // 
            getDiagramDocumentItem.Name = "getDiagramDocumentItem";
            getDiagramDocumentItem.Size = new Size(264, 22);
            getDiagramDocumentItem.Text = "Получить документ с диаграммой";
            getDiagramDocumentItem.Click += GetDiagramDocumentItem_Click;
            // 
            // открытьСправочникToolStripMenuItem
            // 
            открытьСправочникToolStripMenuItem.Name = "открытьСправочникToolStripMenuItem";
            открытьСправочникToolStripMenuItem.Size = new Size(264, 22);
            открытьСправочникToolStripMenuItem.Text = "Открыть справочник";
            открытьСправочникToolStripMenuItem.Click += OpenListToolStripMenuItem_Click;
            // 
            // controlDataTreeCell
            // 
            controlDataTreeCell.ContextMenuStrip = contextMenuStrip;
            controlDataTreeCell.Dock = DockStyle.Fill;
            controlDataTreeCell.Location = new Point(0, 0);
            controlDataTreeCell.Margin = new Padding(4, 3, 4, 3);
            controlDataTreeCell.Name = "controlDataTreeCell";
            controlDataTreeCell.Size = new Size(323, 450);
            controlDataTreeCell.TabIndex = 1;
            // 
            // FormMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(323, 450);
            Controls.Add(controlDataTreeCell);
            KeyPreview = true;
            Name = "FormMain";
            Text = "Основная форма";
            Load += FormMain_Load;
            contextMenuStrip.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private ContextMenuStrip contextMenuStrip;
        private ToolStripMenuItem addProviderItem;
        private ToolStripMenuItem editProviderItem;
        private ToolStripMenuItem removeProviderItem;
        private ToolStripMenuItem getSimpleDocumentItem;
        private ToolStripMenuItem getTableDocumentItem;
        private ToolStripMenuItem getDiagramDocumentItem;
        private ControlsLibraryNet60.Data.ControlDataTreeCell controlDataTreeCell;
        private WinFormsLibrary.ComponentWithText componentWithText;
        private ComponentsLibraryNet60.DocumentWithTable.ComponentDocumentWithTableMultiHeaderExcel componentDocumentWithTableMultiHeaderExcel;
        private ComponentsLibraryNet60.DocumentWithChart.ComponentDocumentWithChartPieWord componentDocumentWithChartPieWord;
        private ComponentsLibraryNet60.DocumentWithChart.ComponentDocumentWithChartBarWord componentDocumentWithChartBarWord1;
        private ToolStripMenuItem открытьСправочникToolStripMenuItem;
    }
}