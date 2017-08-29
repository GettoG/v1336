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
using v1336.ViewModel;

namespace v1336.View
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
