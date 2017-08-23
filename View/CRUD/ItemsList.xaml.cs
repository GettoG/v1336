using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Reflection;
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
using v1336.Rep;
using v1336.ViewModel.CRUD;

namespace v1336.View.CRUD
{
    /// <summary>
    /// Логика взаимодействия для ItemsList.xaml
    /// </summary>
    public partial class ItemsList: Window 
    {
        
        public ItemsList(ItemsData data)
        {
            DataContext = new ItemsListVM(data);
            InitializeComponent();
        }
    }
}
