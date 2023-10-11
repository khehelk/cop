using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CustomComponentLibrary
{
    public partial class CustomListBox : UserControl
    {
        private string layoutString;
        private string startSymbol;
        private string endSymbol;

        public CustomListBox()
        {
            InitializeComponent();
        }

        public void SetLayoutInfo(string layout, string startS, string endS)
        {
            if (layout == null || startS == null || endS == null)
            {
                return;
            }
            layoutString = layout;
            startSymbol = startS;
            endSymbol = endS;
        }

        public int SelectedIndex
        {
            get
            {
                if (listBox.SelectedIndex == -1)
                {
                    return -1;
                }
                return listBox.SelectedIndex;
            }
            set
            {
                if (listBox.SelectedItems.Count != 0)
                {
                    listBox.SelectedIndex = value;
                }
            }
        }

        public T GetObjectFromStr<T>() where T : class, new()
        {
            if (listBox.SelectedIndex == -1)
            {
                return null;
            }
            string row = listBox.SelectedItem.ToString()!;
            T curObject = new T();
            StringBuilder sb = new StringBuilder(row);
            foreach (var property in typeof(T).GetProperties())
            {
                if (!property.CanWrite)
                {
                    continue;
                }

                int borderOne = sb.ToString().IndexOf(startSymbol);
                if (borderOne == -1)
                {
                    break;
                }

                int borderTwo = sb.ToString().IndexOf(endSymbol, borderOne + 1);
                if (borderTwo == -1)
                {
                    break;
                }

                string propertyValue = sb.ToString(borderOne + 1, borderTwo - borderOne - 1);
                sb.Remove(0, borderTwo + 1);
                property.SetValue(curObject, Convert.ChangeType(propertyValue, property.PropertyType));
            }
            return curObject;
        }

        public void FillProperty<T>(T dataObject, int rowIndex, string propertyName)
        {
            if (layoutString == null || startSymbol == null || endSymbol == null)
            {
                return;
            }

            while (listBox.Items.Count <= rowIndex)
            {
                listBox.Items.Add(layoutString);
            }

            string row = listBox.Items[rowIndex].ToString();
            PropertyInfo propertyInfo = dataObject.GetType().GetProperty(propertyName);

            if (propertyInfo != null)
            {
                object propertyValue = propertyInfo.GetValue(dataObject);
                row = row.Replace($"{propertyName}", propertyValue.ToString());
                listBox.Items[rowIndex] = row;
            }
        }
    }
}
