using System;
using System.Windows;
using System.Windows.Controls;
using v1336.Model;
using v1336.Rep;
using v1336.Rep.Dictionary;
using v1336.ViewModel;

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
            CreateMenu();
        }

        private void CreateMenu()
        {
            MenuItem root = new MenuItem{ Header = "Справочники" };
            root.Items.Add(CreateMenuItem("Заказчики", (obj, arg) =>
            {
                var itemData = new ItemsData("Справочник заказчики", new CustomerRep(), typeof(EditCustomer));
                ShowCatalog(itemData);
            }));
            root.Items.Add(CreateMenuItem("Сотрудники", (obj, arg) =>
            {
                var itemData = new ItemsData("Справочник сотрудники", new WorkerRep(), typeof(EditWorker));
                ShowCatalog(itemData);
            }));
            root.Items.Add(CreateMenuItem("Подразделения", (obj, arg) =>
            {
                var itemData = new ItemsData("Справочник подразделения", new DepartmentRep(), typeof(EditDepartment));
                ShowCatalog(itemData);
            }));
            root.Items.Add(CreateMenuItem("Должности", (obj, arg) =>
            {
                var itemData = new ItemsData("Справочник должности", new WorkerPostRep(), typeof(EditEmployeePost));
                ShowCatalog(itemData);
            }));
            menu.Items.Add(root);
        }

        private MenuItem CreateMenuItem(string header, RoutedEventHandler act)
        {
            var item = new MenuItem();
            item.Header = header;
            item.Click += act;
            return item;
        }

        private void ShowCatalog(ItemsData data)
        {
            var win = new ItemsList(data);
            win.Show();
        }

    }
}
