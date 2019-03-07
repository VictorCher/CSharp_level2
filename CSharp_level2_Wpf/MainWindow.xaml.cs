// Чернышов Виктор. Урок 5
/* Задание:
 * Создать WPF -приложение для ведения списка сотрудников компании.
 * 1. Создать сущности Employee и Department и заполнить списки сущностей начальными данными.
 * 2. Для списка сотрудников и списка департаментов предусмотреть визуализацию (отображение).
 * Это можно сделать, например, с использованием ComboBox или ListView.
 * 3. Предусмотреть редактирование сотрудников и департаментов.Должна быть возможность
 * изменить департамент у сотрудника.Список департаментов для выбора можно выводить в
 * ComboBox, и все это можно выводить на дополнительной форме.
 * 4. Предусмотреть возможность создания новых сотрудников и департаментов.Реализовать это
 * либо на форме редактирования, либо сделать новую форму. */

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
    public delegate void Update(int index, string val);
    public delegate void AddEmpl(string index, string val);
    public delegate void AddDep(string index);

    /// <summary>
    /// Описывает сотрудника
    /// </summary>
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
        public static Update update;
        public static AddEmpl addEmpl;
        public static AddDep addDep;
        public static List<string> department; // Список отделов
        List<Employee> employee; // Список сотрудников

        /// <summary>
        /// Редактирует отдел к которому относится сотрудник
        /// </summary>
        /// <param name="index">Порядковый номер сотрудника в списке (начиная с 0)</param>
        /// <param name="val">Название отдела</param>
        public void Edit(int index, string val)
        {
            employee[index].Edit = val;
            listView1.Items.Refresh();
        }

        /// <summary>
        /// Добавляет нового сотрудника
        /// </summary>
        /// <param name="name">Имя сотрудника</param>
        /// <param name="department">Название отдела</param>
        public void Add(string name,string department)
        {
            employee.Add(new Employee(name, department));
            listView1.Items.Refresh();
        }

        /// <summary>
        /// Добавляет новый отдел
        /// </summary>
        /// <param name="dep">Название отдела</param>
        public void Add(string dep)
        {
            department.Add(dep);
        }

        /// <summary>
        /// Инициализация
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            update = Edit;
            addEmpl = Add;
            addDep = Add;
            // Создаем отделы
            department = new List<string> { "ОТК", "Отдел кадров", "КБ", "Сервисный отдел" };
            // Создаем сотрудников
            employee = new List<Employee>();
            employee.Add(new Employee( "Василий","ОТК"));
            employee.Add(new Employee("Петр", "КБ"));
            employee.Add(new Employee("Владимир", "Сервисный отдел"));
            // Выводим всех имеющихся сотрудников на экран
            listView1.ItemsSource = employee;
            foreach (Employee e in employee)
            {
                listView1.Items.Contains(e.Name);
                listView1.Items.Contains(e.Department);
            }     
        }

        /// <summary>
        /// Кнопка редактирования записи о сотруднике
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, RoutedEventArgs e)
        {
            int index = listView1.SelectedIndex;      
            if (index == -1) return;
            string editName = employee[index].Name;
            string editDepartment = employee[index].Department;
            EditEmployee childWindows1 = new EditEmployee();
            childWindows1.Owner = this;
            childWindows1.textBox.Text = editName;
            childWindows1.comboBoxDeportment.Text = editDepartment;
            childWindows1.IndexName = index;
            childWindows1.Title = "Редактирование";
            childWindows1.textBox.IsEnabled = false;
            childWindows1.Show();
        }

        /// <summary>
        /// Кнопка добавления нового сотрудника
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, RoutedEventArgs e)
        {
            EditEmployee childWindows1 = new EditEmployee();
            childWindows1.Owner = this;
            childWindows1.IndexName = -1;
            childWindows1.Title = "Добавление сотрудника";
            childWindows1.textBox.IsEnabled = true;
            childWindows1.Show();
        }

        /// <summary>
        /// Кнопка добавления нового отдела
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, RoutedEventArgs e)
        {
            EditEmployee childWindows1 = new EditEmployee();
            childWindows1.Owner = this;
            childWindows1.IndexName = -1;
            childWindows1.Title = "Добавление отдела";
            childWindows1.comboBoxDeportment.Visibility = Visibility.Collapsed;
            childWindows1.label2.Visibility = Visibility.Collapsed;
            childWindows1.label1.Content = "Отдел";
            childWindows1.Show();
        }
    }
}
