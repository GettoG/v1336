using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using v1336.Rep;
using v1336.Model;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Windows.Input;

namespace v1336.ViewModel
{
    public class ManagersVM : ViewModelBase
    {
        private ManagerRep rep;
        public ManagersVM()
        {
            rep = new ManagerRep();
        }

        Manager _currentManager;
        public Manager CurrentManager
        {
            get
            {
                if (_currentManager == null)
                    _currentManager = new Manager();
                return _currentManager;
            }
            set
            {
                _currentManager = value;
                RaisePropertyChanged("CurrentManager");
            }
        }

        ObservableCollection<Manager> _managers;
        public ObservableCollection<Manager> Managers
        {
            get
            {
                if (_managers == null)
                {
                    _managers = rep.GetAll();
                    _managers.CollectionChanged += UpdateManager;
                }
                return _managers;
            }
        }

        private void UpdateManager(object sender, NotifyCollectionChangedEventArgs e)
        {
            RaisePropertyChanged("Managers");
        }

        RelayCommand _addManagerCommand;
        public ICommand AddManager
        {
            get
            {
                if (_addManagerCommand == null)
                    _addManagerCommand = new RelayCommand(ExecuteAddManagerCommand, CanExecuteAddManagerCommand);
                return _addManagerCommand;
            }
        }
        public void ExecuteAddManagerCommand()
        {
            rep.Add(CurrentManager);
            CurrentManager = null;
        }
        public bool CanExecuteAddManagerCommand()
        {
            return !string.IsNullOrEmpty(CurrentManager.LastName) && !string.IsNullOrEmpty(CurrentManager.FirstName) && !string.IsNullOrEmpty(CurrentManager.FatherName);
        }

        private RelayCommand _deleteManagerCommand;
        public RelayCommand DeleteManager
        {
            get
            {
                if (_deleteManagerCommand == null)
                    _deleteManagerCommand = new RelayCommand(ExecuteDeleteManagerCommand);
                return _deleteManagerCommand;
            }
        }



        public void ExecuteDeleteManagerCommand()
        {
            if (SelectedManager == null || SelectedManager.Id == 0) return;
            rep.Delete(SelectedManager);
            CurrentManager = null;
        }

        public Manager SelectedManager
        {
            get { return _currentManager; }
            set
            {
                _currentManager = value;
                RaisePropertyChanged("selectedManager");
            }
        }
    }
}
