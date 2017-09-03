using System;
using System.Windows;
using System.Windows.Controls;
using v1336.Model;
using v1336.Rep;
using v1336.Rep.Dictionary;
using v1336.ViewModel;

namespace v1336.View
{
    public partial class EditWorker : Window
    {
        public int Id { get; set; }
        private readonly WorkerRep rep = new WorkerRep();

        public Worker Selected { get; set; }
        private readonly ItemsListVM ParentWindowVM;

        public const string TITLE_NAME = "сотрудника";

        public EditWorker(ItemsListVM parent, int id)
        {
            Id = id;
            ParentWindowVM = parent;
            if (Id == 0)
            {
                Title = "Добавить " + TITLE_NAME;
                Selected = new Worker();
            }
            else
            {
                Title = "Редактировать " + TITLE_NAME; ;
                Selected = rep.GetById(id);
            }
            InitializeComponent();
            cmb_Departments.ItemsSource = new DepartmentRep().GetAll();
            cmb_Post.ItemsSource = new WorkerPostRep().GetAll();
            DataContext = Selected;
            //cmb_Departments.SelectedValue = Selected.DepartmentId;
            //cmb_Post.SelectedValue = Selected.EmployeePostId;
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
