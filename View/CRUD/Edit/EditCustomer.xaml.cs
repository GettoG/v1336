using System;
using System.Windows;
using v1336.Model;

namespace v1336.View.CRUD.Edit
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
