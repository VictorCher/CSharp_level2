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
using System.Windows.Shapes;

namespace CSharp_level2_Wpf
{
    /// <summary>
    /// Interaction logic for EditEmployee.xaml
    /// </summary>
    public partial class EditEmployee : Window
    {
        public int IndexName { get; set; }

        /// <summary>
        /// Инициализация окна ввода данных
        /// </summary>
        public EditEmployee()
        {
            InitializeComponent();
            comboBoxDeportment.ItemsSource = MainWindow.department;
        }

        /// <summary>
        /// Кнопка подтвержнения введенных данных
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_Click(object sender, RoutedEventArgs e)
        {
            string val = comboBoxDeportment.Text;
            if (IndexName != -1)
            {
                // Если окно было открыто для редактирования сотрудника (отдела к которому относится)
                MainWindow.employee[IndexName].Edit = val;
                MainWindow.UpdateD.Invoke(val);
            }
            else
            {
                if (comboBoxDeportment.IsVisible == true && val != "")
                {
                    // Если окно было открыто для добавления нового сотрудника
                    MainWindow.employee.Add(new Employee(textBox.Text, val));
                    MainWindow.InsertE.Invoke(textBox.Text,val);
                }
                else if (textBox.Text != "")
                {
                    // Если окно было открыто для добавления нового отдела
                    MainWindow.department.Add(textBox.Text);
                    MainWindow.InsertD.Invoke(textBox.Text);
                }
            }   
            Close();
        }
    }
}
