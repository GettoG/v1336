using System;
using System.Windows;
using v1336.Model;
using v1336.Rep.Dictionary;
using v1336.ViewModel;

namespace v1336.View
{
    /// <summary>
    /// Логика взаимодействия для EditCustomer.xaml
    /// </summary>
    public partial class EditEmployeePost : Window
    {
        public int Id { get; set; }
        private readonly WorkerPostRep rep = new WorkerPostRep();

        public WorkerPost Selected { get; set; }
        private readonly ItemsListVM ParentWindowVM;

        public const string TITLE_NAME = "должность";

        public EditEmployeePost(ItemsListVM parent, int id)
        {
            Id = id;
            ParentWindowVM = parent;
            if (Id == 0)
            {
                Title = "Добавить " + TITLE_NAME;
                Selected = new WorkerPost();
            }
            else
            {
                Title = "Редактировать " + TITLE_NAME; ;
                Selected = rep.GetById(id);
            }
            InitializeComponent();
            DataContext = Selected;
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
                    rep.Add(Selected);
                }
                else
                {
                    rep.Update(Selected);
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
