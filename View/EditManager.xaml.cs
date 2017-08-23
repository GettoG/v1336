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
using v1336.Rep;
using v1336.View.CRUD;
using v1336.ViewModel.CRUD;

namespace v1336.View
{
    /// <summary>
    /// Логика взаимодействия для EditManager.xaml
    /// </summary>
    public partial class EditManager : Window
    {
        public int Id { get; set; }
        private ManagerRep rep { get; set; }

        public Manager SelectedManager { get; set; }
        private ItemsListVM ParentWindowVM { get; set; }
        public EditManager(ItemsListVM parent, int id)
        {
            Id = id;
            rep = new ManagerRep();
            ParentWindowVM = parent;
            if (Id == 0)
            {
                Title = "Добавить менеджера";
                SelectedManager = new Manager();
            }
            else
            {
                Title = "Редактировать менеджера";
                SelectedManager = rep.GetById(id);
            }
            InitializeComponent();
            DataContext = SelectedManager;
            this.UpdateLayout();
        }

        private void btn_Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btn_Save_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (Id == 0)
                {
                    rep.Add(SelectedManager);
                }
                else
                {
                    rep.Update(SelectedManager);
                }
                ParentWindowVM.Update();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        
    }
}
