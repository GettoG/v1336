using System;
using System.Windows;
using GalaSoft.MvvmLight.Command;
using v1336.Model;
using v1336.Rep.Dictionary;
using v1336.Rep.Document;
using v1336.ViewModel;

namespace v1336.View.Document
{
    /// <summary>
    /// Логика взаимодействия для OrderV.xaml
    /// </summary>
    public partial class OrderV : Window
    {
        public OrderV(int id)
        {
            InitializeComponent();
            DataContext = new OrderVM(id, this);
            
            //cmb_Cust.ItemsSource = new CustomerRep().GetAll();
            //cmb_Manager.ItemsSource = new WorkerRep().GetAll();
            //cmb_NomCat.ItemsSource = new NomenclatureCategoryRep().GetAll();
            //cmb_Nom.ItemsSource = new NomenclatureRep().GetAll();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }






        //public int Id { get; set; }
        //private readonly OrderRowRep rep = new OrderRowRep();

        //public OrderRow Selected { get; set; }

        //private void btn_Exit_Click(object sender, RoutedEventArgs e)
        //{
        //    this.Close();
        //}

        //private void btn_Save_Click(object sender, RoutedEventArgs e)
        //{
        //    try
        //    {
        //        if (Id == 0)
        //        {
        //            rep.Add(Selected);
        //        }
        //        else
        //        {
        //            rep.Update(Selected);
        //        }

        //        this.Close();
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //}


        //private void btn_Add_Row(object sender, RoutedEventArgs e)
        //{
        //    throw new NotImplementedException();
        //}

        //private void btn_Delete_Row(object sender, RoutedEventArgs e)
        //{
        //    throw new NotImplementedException();
        //}

        //private void cmb_NomCat_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        //{

        //}
    }
}
