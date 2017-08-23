using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Data.Entity.Migrations.Model;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using v1336.Model;
using v1336.Rep;
using v1336.View;

namespace v1336.ViewModel.CRUD
{
    public class ItemsListVM : ViewModelBase
    {
        private IRep rep;
        private ItemsData data;
        public ItemsListVM()
        {
        }

        public ItemsListVM(ItemsData data)
        {
            rep = data.Rep;
            this.data = data;
            this.Title = data.Title;
        }

        public string Title { get; set; }
        public IDbObject CurrentItem { get; set; }
        public IDbObject SelectedItem { get; set; }

        public ObservableCollection<IDbObject> Items => rep.GetAll();

        private int GetSelectedId => SelectedItem?.Id ?? 0;

        public void Update()
        {
            RaisePropertyChanged("Items");
        }
        public RelayCommand AddItem => new RelayCommand(() =>
        {
            data.GetWindow(this,0).Show();
        });

        public RelayCommand UpdateItem => new RelayCommand(() =>
        {
            if (GetSelectedId > 0)
            {
                data.GetWindow(this, GetSelectedId).Show();
            }
           
        });

        public RelayCommand DeleteItem => new RelayCommand(() =>
        {
            if (GetSelectedId == 0) return;
            rep.Delete(SelectedItem);
            CurrentItem = null;
            RaisePropertyChanged("Items");
        });
      

      
    }
}
