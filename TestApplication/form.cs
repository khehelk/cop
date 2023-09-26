namespace TestApplication
{
    public partial class form : Form
    {
        public form()
        {
            InitializeComponent();

            string pattern = @"^(?:\+7|8)[ ]?\d{3}[ ]?\d{3}[ ]?\d{2}[ ]?\d{2}$";
            customTextBox1.Pattern = pattern;
            customTextBox1.Example = "Пример: +7(8) 123 456 78 90";

            customListBox1.SetLayoutInfo("Какой-то текст из свойств - {Name}", "{", "}");

            var person1 = new Person { Name = "Вася" };
            var person2 = new Person { Name = "Коля"};
            var person3 = new Person { Name = "Петя" };

            customListBox1.FillProperty(person1, 0, "Name");
            customListBox1.FillProperty(person2, 1, "Name");
            customListBox1.FillProperty(person3, 2, "Name");
        }

        private void buttonCheckTextBox_Click(object sender, EventArgs e)
        {
            label1.Text = customTextBox1.InputValue;
        }

        private void buttonFillComboBox_Click(object sender, EventArgs e)
        {
            customComboBox1.AddToCustomComboBox.Add("Вася");
            customComboBox1.AddToCustomComboBox.Add("Коля");
            customComboBox1.AddToCustomComboBox.Add("Петя");
        }

        private void buttonClearComboBox_Click(object sender, EventArgs e)
        {
            customComboBox1.Clear();
        }

        private void buttonGetObj_Click(object sender, EventArgs e) => labelObjFromStr.Text = customListBox1.GetObjectFromStr<Person>().Name;
    }

    public class Person
    {
        public string Name { get; set; }
    }
}
