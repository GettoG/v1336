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
using v1336.Rep.Dictionary;
using v1336.ViewModel;

namespace v1336.View.Dictionary
{
    /// <summary>
    /// Логика взаимодействия для EditNomenclatureCategory.xaml
    /// </summary>
    public partial class EditNomenclatureCategory : Window
    {
        public int Id { get; set; }
        private readonly NomenclatureCategoryRep rep = new NomenclatureCategoryRep();

        public NomenclatureCategory Selected { get; set; }
        private readonly ItemsListVM ParentWindowVM;

        public const string TITLE_NAME = "клиента";

        public EditNomenclatureCategory(ItemsListVM parent, int id)
        {
            Id = id;
            ParentWindowVM = parent;
            if (Id == 0)
            {
                Title = "Добавить " + TITLE_NAME;
                Selected = new NomenclatureCategory();
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
