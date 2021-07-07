// Чернышов Виктор. Урок 7
/* Задание:
 * Создать WPF -приложение для ведения списка сотрудников компании, используя
 * связывание данных, ListView, ObservableCollection и INotifyPropertyChanged.
 * 1. Создать сущности Employee и Department и заполнить списки сущностей начальными данными.
 * 2. Для списка сотрудников и списка департаментов предусмотреть визуализацию (отображение).
 * Это можно сделать, например, с использованием ComboBox или ListView.
 * 3. Предусмотреть редактирование сотрудников и департаментов.Должна быть возможность
 * изменить департамент у сотрудника.Список департаментов для выбора можно выводить в
 * ComboBox, и все это можно выводить на дополнительной форме.
 * 4. Предусмотреть возможность создания новых сотрудников и департаментов.Реализовать это
 * либо на форме редактирования, либо сделать новую форму. */

using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
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
    public delegate void updateDepartment(string n, string d);
    public delegate void insertDepartment(string d);
    public delegate void insertEmployee(string n, string d);
    /// <summary>
    /// Описывает сотрудника
    /// </summary>
    public class Employee : INotifyPropertyChanged
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
        public string Edit
        {
            set
            {
                department = value;
                NotifyPropertyChanged(nameof(department));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static ObservableCollection<string> department; // Список отделов
        public static ObservableCollection<Employee> employee; // Список сотрудников 
        MyWorkingWithDatabase myDB;
        public static updateDepartment UpdateD;
        public static insertDepartment InsertD;
        public static insertEmployee InsertE;

        /// <summary>
        /// Инициализация
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();

            // Создаем отделы
            department = new ObservableCollection<string>(); // { "ОТК", "Отдел кадров", "КБ", "Сервисный отдел" };
            // Создаем сотрудников
            employee = new ObservableCollection<Employee>();
            /*employee.Add(new Employee( "Василий","ОТК"));
            employee.Add(new Employee("Петр", "КБ"));
            employee.Add(new Employee("Владимир", "Сервисный отдел"));*/
            myDB = new MyWorkingWithDatabase();
            myDB.ReadDB();
            UpdateD = myDB.UpdateDB;
            InsertD = myDB.InsertDB;
            InsertE = myDB.InsertDB;
            listView1.ItemsSource = employee;           
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

        private void button_Click(object sender, RoutedEventArgs e)
        {
            string connectionString = @"Data Source=(localdb)\mssqllocaldb;
                                        Initial Catalog=lesson7;
                                        Integrated Security=True;
                                        Pooling=True";
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand();
            //connection.Open();
            command.Connection = connection;
            //command.CommandText = @"DROP TABLE [People];";
            //command.CommandText = @"INSERT INTO [Employees] (Name, Department) VALUES (N'Владимир',N'Сервисный отдел');";
            //command.ExecuteNonQuery();
            //command.CommandText = @"UPDATE [People] SET FIO = @Сидоров_Сидор_Сидорович";
            //SqlParameter param = new SqlParameter("@Сидоров_Сидор_Сидорович", "Сидоров Сидор Сидорович");
            //command.Parameters.AddWithValue("@Сидоров_Сидор_Сидорович", "Сидоров Сидор Сидорович");
            //command.Connection = connection;
            //command.CommandText = @"SELECT * FROM People";

            /*SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            if (reader.HasRows) // Если есть данные
            {
                while (reader.Read()) // Построчно считываем данные
                {
                    var vId = Convert.ToInt32(reader.GetValue(0));
                    var vFIO = reader.GetString(1);
                    var vEmail = reader["Email"];
                    var vPhone = reader.GetString(reader.GetOrdinal("Phone"));
                }
            }*/
            /*SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = command;
            DataSet ds = new DataSet();
            adapter.Fill(ds);*/
            


/*
            command.CommandText = "SELECT COUNT(*) FROM [Employee]";
            Console.WriteLine(command.ExecuteScalar());
            command.ExecuteNonQuery();

            connection.Close();*/
        }
    }
}
