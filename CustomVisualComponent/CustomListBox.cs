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

namespace CustomVisualComponent
{
    public partial class CustomListBox : UserControl
    {
        public CustomListBox()
        {
            InitializeComponent();
        }

        public void AddItem(object obj, int rowIndex, string propertyName)
        {
            PropertyInfo propertyInfo = obj.GetType().GetProperty(propertyName);
            if (propertyInfo != null)
            {
                object value = propertyInfo.GetValue(obj);
                listBox.Items.Insert(rowIndex, value);
            }
            else
            {
                throw new ArgumentException($"Свойство или поле {propertyName} не найдено в типе {obj.GetType().FullName}");
            }
        }

        public void RemoveItem(int index)
        {
            if (index >= 0 && index < listBox.Items.Count)
            {
                listBox.Items.RemoveAt(index);
            }
        }
    }
}
