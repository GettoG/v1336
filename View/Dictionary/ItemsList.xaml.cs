using System.Windows;
using v1336.ViewModel;

namespace v1336.View
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
