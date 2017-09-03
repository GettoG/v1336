using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using v1336.Model;
using v1336.Rep;
using v1336.Rep.Dictionary;
using v1336.Rep.Document;
using v1336.View;
using OrderV = v1336.View.Document.OrderV;

namespace v1336.ViewModel 
{
    public class MainVM : ViewModelBase
    {
        public ObservableCollection<Order> Orders => new ObservableCollection<Order>(Rep.GetAll());
       
        private OrderRep Rep { get; set; } = new OrderRep();

        public Order SelectedOrder { get; set; }
        public MainVM()
        {

        }

        public RelayCommand DeleteOrder => new RelayCommand(() =>
        {
            if (SelectedOrder == null || SelectedOrder.Id == 0) return;
            Rep.Delete(SelectedOrder);
            SelectedOrder = null;
            RaisePropertyChanged("Orders");
        });


        public RelayCommand AddOrder => new RelayCommand(() =>
        {
            OrderV win = new OrderV(0);
            win.Show();
            RaisePropertyChanged("Orders");
        });

        public RelayCommand UpdateOrder => new RelayCommand(() =>
        {
            OrderV win = new OrderV(SelectedOrder.Id);
            win.Show();
            RaisePropertyChanged("Orders");
        });
    }
}