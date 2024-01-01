using PluginsConventionLibrary;
using System.Reflection;

namespace WinFormsAppByPlugins
{
    public partial class FormMain : Form
    {
        private readonly Dictionary<string, IPluginsConvention> _plugins;
        private string _selectedPlugin;

        public FormMain()
        {
            InitializeComponent();
            _plugins = new();
            LoadPlugins();
            _selectedPlugin = string.Empty;
        }

        private void LoadPlugins()
        {
            List<IPluginsConvention> pluginsList = GetPlugins();            

            foreach (var plugin in pluginsList)
            {
                _plugins[plugin.PluginName] = plugin;
                CreateMenuItem(plugin.PluginName);
            }
        }

        private List<IPluginsConvention> GetPlugins()
        {
            string currentDir = Environment.CurrentDirectory;
            string pluginsDir = Directory.GetParent(currentDir)?.Parent?.Parent?.Parent?.FullName + "\\Plugins";
            string[] dllFiles = Directory.GetFiles(
                pluginsDir,
                "*.dll",
                SearchOption.AllDirectories
            );
            List<IPluginsConvention> plugins = new();
            foreach (string dllFile in dllFiles)
            {
                try
                {
                    Assembly assembly = Assembly.LoadFrom(dllFile);
                    Type[] types = assembly.GetTypes();
                    foreach (Type type in types)
                    {
                        if (typeof(IPluginsConvention).IsAssignableFrom(type) && !type.IsInterface)
                        {
                            if (Activator.CreateInstance(type) is IPluginsConvention plugin)
                            {
                                plugins.Add(plugin);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        ex.Message
                    );
                }
            }
            return plugins;
        }

        private void CreateMenuItem(string pluginName)
        {
            ToolStripMenuItem menuItem = new(pluginName);
            menuItem.Click += (object? sender, EventArgs e) =>
            {
                UserControl userControl = _plugins[pluginName].GetControl;
                if (userControl != null)
                {
                    panelControl.Controls.Clear();
                    userControl.Dock = DockStyle.Fill;
                    _plugins[pluginName].ReloadData();
                    _selectedPlugin = pluginName;
                    panelControl.Controls.Add(userControl);
                }
            };
            ControlsStripMenuItem.DropDownItems.Add(menuItem);
        }

        private void FormMain_KeyDown(object sender, KeyEventArgs e)
        {
            if (string.IsNullOrEmpty(_selectedPlugin) ||
            !_plugins.ContainsKey(_selectedPlugin))
            {
                return;
            }
            if (!e.Control)
            {
                return;
            }
            switch (e.KeyCode)
            {
                case Keys.I:
                    ShowThesaurus();
                    break;
                case Keys.A:
                    AddNewElement();
                    break;
                case Keys.U:
                    UpdateElement();
                    break;
                case Keys.D:
                    DeleteElement();
                    break;
                case Keys.S:
                    CreateSimpleDoc();
                    break;
                case Keys.T:
                    CreateTableDoc();
                    break;
                case Keys.C:
                    CreateChartDoc();
                    break;
            }
        }

        private void ShowThesaurus()
        {
            _plugins[_selectedPlugin].GetThesaurus()?.Show();
        }

        private void AddNewElement()
        {
            var form = _plugins[_selectedPlugin].GetForm(null);
            if (form != null && form.ShowDialog() == DialogResult.OK)
            {
                _plugins[_selectedPlugin].ReloadData();
            }
        }

        private void UpdateElement()
        {
            var element = _plugins[_selectedPlugin].GetElement;
            if (element == null)
            {
                MessageBox.Show(
                    "Нет выбранного элемента", 
                    "Ошибка",
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Error
                );
                return;
            }
            var form = _plugins[_selectedPlugin].GetForm(element);
            if (form != null && form.ShowDialog() == DialogResult.OK)
            {
                _plugins[_selectedPlugin].ReloadData();
            }
        }

        private void DeleteElement()
        {
            if (MessageBox.Show(
                "Удалить выбранный элемент", 
                "Удаление",
                MessageBoxButtons.YesNo, 
                MessageBoxIcon.Question) != DialogResult.Yes)
            {
                return;
            }
            var element = _plugins[_selectedPlugin].GetElement;
            if (element == null)
            {
                MessageBox.Show(
                    "Нет выбранного элемента", 
                    "Ошибка",
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Error
                );
                return;
            }
            if (_plugins[_selectedPlugin].DeleteElement(element))
            {
                _plugins[_selectedPlugin].ReloadData();
            }
        }

        private void CreateSimpleDoc()
        {
            SaveFileDialog saveFileDialog = new()
            {
                Filter = "PDF Files|*.pdf"
            };
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                _plugins[_selectedPlugin].CreateSimpleDocument(new PluginsConventionSaveDocument() { FileName = saveFileDialog.FileName });
                
            }
        }
        private void CreateTableDoc()
        {
            SaveFileDialog saveFileDialog = new()
            {
                Filter = "Excel Files|*.xlsx"
            };
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                _plugins[_selectedPlugin].CreateTableDocument(new PluginsConventionSaveDocument() { FileName = saveFileDialog.FileName });
                
            }
        }
        private void CreateChartDoc()
        {
            SaveFileDialog saveFileDialog = new()
            {
                Filter = "Word Files|*.docx"
            };
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                _plugins[_selectedPlugin].CreateChartDocument(new PluginsConventionSaveDocument() { FileName = saveFileDialog.FileName });               
            }
        }

        private void ThesaurusToolStripMenuItem_Click(object sender, EventArgs e) => ShowThesaurus();
        private void AddElementToolStripMenuItem_Click(object sender, EventArgs e) => AddNewElement();
        private void UpdElementToolStripMenuItem_Click(object sender, EventArgs e) => UpdateElement();
        private void DelElementToolStripMenuItem_Click(object sender, EventArgs e) => DeleteElement();
        private void SimpleDocToolStripMenuItem_Click(object sender, EventArgs e) => CreateSimpleDoc();
        private void TableDocToolStripMenuItem_Click(object sender, EventArgs e) => CreateTableDoc();
        private void ChartDocToolStripMenuItem_Click(object sender, EventArgs e) => CreateChartDoc();
    }
}