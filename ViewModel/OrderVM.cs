using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using v1336.Model;
using v1336.Rep.Dictionary;
using v1336.Rep.Document;

namespace v1336.ViewModel
{
    public class OrderVM : ViewModelBase
    {
        OrderRep rep = new OrderRep();

        public List<Customer> Customers { get; set; }
        public List<Worker> Managers { get; set; }
        public List<Nomenclature> Nomenclatures { get; set; }
        public List<Nomenclature> CurrentNomenclatures { get; set; }
        public List<NomenclatureCategory> NomenclatureCategorys { get; set; }
        public Order Order { get; set; } = new Order();
        public OrderRow CurrentRow { get; set; } = new OrderRow() { Quantity = 1};
        public OrderRow SelectedRow { get; set; }
        private NomenclatureCategory snc;
        public NomenclatureCategory Snc
        {
            get { return snc; }
            set
            {
                if (snc == value)
                    return;
                snc = value;
                CurrentNomenclatures = Nomenclatures.Where(x => x.NomenclatureCategoryId == snc.Id).ToList();
                RaisePropertyChanged("CurrentNomenclatures");

            }
        }

        public Window Parent { get; set; }

        public OrderVM(int id, Window parent = null)
        {
            Parent = parent;
            Order.Date_b = DateTime.Now;
            Order.Date_e = DateTime.Now;
           
            Customers = new CustomerRep().GetAll().ToList();
            Managers = new WorkerRep().GetAll().Where(x=>x.EmployeePostId == 1).ToList();
            NomenclatureCategorys = new NomenclatureCategoryRep().GetAll().ToList();
            Nomenclatures = new NomenclatureRep().GetAll().ToList();
            if (id != 0)
            {
                Order = rep.GetById(id);
                Rows = new ObservableCollection<OrderRow>(Order.Rows);
            }

        }


        public RelayCommand DeleteRow => new RelayCommand(() =>
        {
            Rows.Remove(SelectedRow);
        });

        public ObservableCollection<OrderRow> Rows { get; set; } = new ObservableCollection<OrderRow>();

        public RelayCommand AddRow => new RelayCommand(() =>
        {
            OrderRow row = CurrentRow.Clone() as OrderRow;
            row.OrderId = Order.Id;
            Rows.Add(row);
        });


        public RelayCommand AddOrUpdateItem => new RelayCommand(() =>
        {

            try
            {
                Order.Rows = Rows.ToList();
                if (Order.Id == 0) rep.Add(Order);
                else rep.Update(Order);
                Parent.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        });

   
    }
}