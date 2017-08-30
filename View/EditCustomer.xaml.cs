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
using v1336.Model;

namespace v1336.View
{
    /// <summary>
    /// Логика взаимодействия для EditCustomer.xaml
    /// </summary>
    public partial class EditCustomer : Window
    {
        public EditCustomer()
        {
            InitializeComponent();
        }

        public Customer Current { get; set; }


        private void btn_Save_Click(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void btn_Exit_Click(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
