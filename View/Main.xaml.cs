using System.Windows;
using System.Windows.Controls;
using v1336.Model;
using v1336.Rep;
using v1336.View.CRUD;
using v1336.ViewModel.CRUD;

namespace v1336.View
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void MenuItem_Click_Customers(object sender, RoutedEventArgs e)
        {
            var itemData = new ItemsData("Справочник заказчиков", new CustomerRep(), typeof(EditCustomer));
            ShowCatalog(itemData);
        }

        private void ShowCatalog(ItemsData data)
        {
            var win = new ItemsList(data);
            win.Show();
        }

        private void MenuItem_Click_Managers(object sender, RoutedEventArgs e)
        {
            var itemData = new ItemsData("Справочник менеджеров", new ManagerRep(), typeof(EditManager));
            ShowCatalog(itemData);
        }

        private void MenuItem_Click_Departments(object sender, RoutedEventArgs e)
        {
            var itemData = new ItemsData("Справочник подразделений", new DepartmentRep(), typeof(EditDepartment));
            ShowCatalog(itemData);
        }

        private void MenuItem_Click_Nomenclatures(object sender, RoutedEventArgs e)
        {
            var itemData = new ItemsData("Справочник изделий", new NomenclatureRep(), typeof(EditNomenclature));
            ShowCatalog(itemData);
        }

        private void MenuItem_Click_Employees(object sender, RoutedEventArgs e)
        {
            var itemData = new ItemsData("Справочник сотрудников", new EmployeeRep(), typeof(EditEmployee));
            ShowCatalog(itemData);
        }

        private void MenuItem_Click_Priorities(object sender, RoutedEventArgs e)
        {
            Priorities win = new Priorities { Owner = this };
            win.Show();
        }

        private void MenuItem_Click_Problems(object sender, RoutedEventArgs e)
        {
            Problems win = new Problems { Owner = this };
            win.Show();
        }

        private void MenuItem_Click_Authorization(object sender, RoutedEventArgs e)
        {
            Authorization win = new Authorization { Owner = this };
            win.Show();
        }
    }
}
