using System.Windows;
using v1336.Model;
using v1336.ViewModel;

namespace v1336.View.Document
{
    /// <summary>
    /// Логика взаимодействия для OrderV.xaml
    /// </summary>
    public partial class OrderV : Window
    {
        public OrderV(int id)
        {
            InitializeComponent();
            if (id != 0)
            {
                DataContext = new OrderVM(id);
            }
            
        }
    }
}
