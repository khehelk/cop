using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ComponentsLibraryNet60;

namespace TestApplication
{
    public partial class form : Form
    {
        public form()
        {
            InitializeComponent();
            customComboBox1.Items = new List<string> { "Вася", "Коля", "Петя" };
            
            var person1 = new Person { Name = "Вася" };
            var person2 = new Person { Name = "Коля", Age = 10 };
            var person3 = new Person { Name = "Петя" };

            customListBox1.AddItem(person1, 0, "Name");
            customListBox1.AddItem(person2, 1, "Age");
            customListBox1.AddItem(person3, 2, "Name");
        }
    }

    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }
}
