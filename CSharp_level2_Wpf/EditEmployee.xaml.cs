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
        int indexName;
        public int IndexName { set { indexName = value; } }

        /// <summary>
        /// Инициализация окна ввода данных
        /// </summary>
        public EditEmployee()
        {
            InitializeComponent();
            comboBoxDeportment.ItemsSource = MainWindow.department;
            foreach (string dep in MainWindow.department)
                comboBoxDeportment.Items.Contains(dep);
        }

        /// <summary>
        /// Кнопка подтвержнения введенных данных
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_Click(object sender, RoutedEventArgs e)
        {
            string val = comboBoxDeportment.Text;
            if (indexName != -1)
                // Если окно было открыто для редактирования
                MainWindow.update(indexName, val);
            else
            {
                if(comboBoxDeportment.IsVisible == true && val != "")
                    // Если окно было открыто для добавления нового сотрудника
                    MainWindow.addEmpl(textBox.Text, val);
                else if(textBox.Text != "")
                    // Если окно было открыто для добавления нового отдела
                    MainWindow.addDep(textBox.Text);
            }   
            Close();
        }
    }
}
