using System;
using System.Windows;
using v1336.Model;
using v1336.Rep;
using v1336.ViewModel.CRUD;

namespace v1336.View.CRUD.Edit
{
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
