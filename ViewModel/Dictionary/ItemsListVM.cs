using System.Collections.Generic;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using v1336.Model;
using v1336.Rep;

namespace v1336.ViewModel
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

        public IEnumerable<IDbObject> Items => rep.GetAll();

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
