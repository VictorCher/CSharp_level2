using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CSharp_level2_Wpf
{
    
    class Employee
    {
        string name;
        string department;
        public Employee(string name, string department)
        {
            this.name = name;
            this.department = department;
        }
        public string Name => name;
        public string Department => department;
        public string Edit { set { department = value; } }
    }

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public delegate void update(int index, string val);
        List<string> department;
        List<Employee> employee;
        public void Edit(int index, string val)
        {
            employee[index].Edit = val;
        }
        public void Update()
        {
            listView1.ItemsSource = employee;
            foreach (Employee e in employee)
            {
                listView1.Items.Contains(e.Name);
                listView1.Items.Contains(e.Department);
            }
        }
        public MainWindow()
        {
            InitializeComponent();
            department = new List<string> { "ОТК", "Отдел кадров", "КБ", "Сервисный отдел" };
            employee = new List<Employee>();
            employee.Add(new Employee( "Василий","ОТК"));
            employee.Add(new Employee("Петр", "КБ"));
            employee.Add(new Employee("Владимир", "Сервисный отдел"));
            Update();
            
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            int index = listView1.SelectedIndex;      
            if (index == -1) return;
            string editName = employee[index].Name;
            string editDepartment = employee[index].Department;
            EditEmployee childWindows1 = new EditEmployee();
            childWindows1.Owner = this;
            childWindows1.textBox.Text = editName;
            
            childWindows1.Show();
            foreach (Employee emp in employee)
            {
                childWindows1.comboBox.Items.Add(emp.Department);
            }
            childWindows1.comboBox.Text = editDepartment;
        }
    }
}
