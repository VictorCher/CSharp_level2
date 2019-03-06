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
        public EditEmployee()
        {
            InitializeComponent();
        }

        private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = comboBox.SelectedIndex;
            string val = textBox.Text;
            if (index == -1 && val != null) return;
            MainWindow.update(index,val);
            //string editName = employee[index].Name;
            //string editDepartment = MainWindow.employee[index].Edit;
        }

        
    }
}
