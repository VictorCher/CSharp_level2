// Чернышов Виктор. Урок 8
/* Задание:
 * Изменить WPF-приложение для ведения списка сотрудников компании (из урока 7), используя
 * веб-сервисы . Разделите приложение на две части. Первая часть – клиентское приложение,
 * отображающее данные. Вторая часть – веб-сервис и код, связанный с извлечением данных из БД.
 * Приложение реализует только просмотр данных. При разработке приложения допустимо использовать
 * любой из рассмотренных типов веб-сервисов.
 * 1. Создать таблицы Employee и Department в БД MSSQL Server и заполнить списки сущностей
 * начальными данными;
 * 2. Для списка сотрудников и списка департаментов предусмотреть визуализацию (отображение);
 * 3. Разработать формы для отображения отдельных элементов списков сотрудников и департаментов.*/

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
using System.Net.Http;
using System.Net.Http.Headers;

namespace WebAPI_Client
{ 
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<Employee> employees = new List<Employee>();
        public MainWindow()
        {
            InitializeComponent();
            HttpClient client = new HttpClient();
            HttpResponseMessage result = client.GetAsync(@"http://localhost:55535/api/employees/").Result;
            employees.AddRange(result.Content.ReadAsAsync<IEnumerable<Employee>>().Result);
            dataGrid.ItemsSource = employees;
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage result;
            if (textBox.Text == "") result = client.GetAsync(@"http://localhost:55535/api/employees/").Result;
            else result = client.GetAsync(@"http://localhost:55535/api/employees/" + textBox.Text).Result;
            employees.Clear();
            employees.AddRange(result.Content.ReadAsAsync<IEnumerable<Employee>>().Result);
            dataGrid.ItemsSource = employees;
            dataGrid.Items.Refresh();
        }
    }
}
