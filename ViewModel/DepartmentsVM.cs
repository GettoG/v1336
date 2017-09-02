using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using v1336.Rep;
using v1336.Model;

namespace v1336.ViewModel
{
    class DepartmentsVM : ViewModelBase
    {
        private DepartmentRep rep;
        public DepartmentsVM()
        {
            rep = new DepartmentRep();
        }

        Department _currentDepartment;
        public Department CurrentDepartment
        {
            get
            {
                if (_currentDepartment == null)
                    _currentDepartment = new Department();
                return _currentDepartment;
            }
            set
            {
                _currentDepartment = value;
                RaisePropertyChanged("CurrentDepartment");
            }
        }

        private ObservableCollection<Department> _departments;
        public ObservableCollection<Department> Departments
        {
            get
            {
                if (_departments == null)
                {
                    _departments = new ObservableCollection<Department>(rep.GetAll());
                    _departments.CollectionChanged += UpdateDepartment;
                }
                return _departments;
            }

        }

        private void UpdateDepartment(object sender, NotifyCollectionChangedEventArgs e)
        {
            RaisePropertyChanged("Departments");
        }

        private RelayCommand _addDepartmentCommand;
        public RelayCommand AddDepartment
        {
            get
            {
                if (_addDepartmentCommand == null)
                    _addDepartmentCommand = new RelayCommand(ExecuteAddDepartmentCommand, CanExecuteAddDepartmentCommand);
                return _addDepartmentCommand;
            }
        }
        public void ExecuteAddDepartmentCommand()
        {
            rep.Add(CurrentDepartment);
            CurrentDepartment = null;
        }
        public bool CanExecuteAddDepartmentCommand()
        {
            return !string.IsNullOrEmpty(CurrentDepartment.Name);
            /*if (string.IsNullOrEmpty(CurrentCustomer.Name))
                return false;
            return true;*/
        }

        private RelayCommand _deleteDepartmentCommand;
        public RelayCommand DeleteDepartment
        {
            get
            {
                if (_deleteDepartmentCommand == null)
                    _deleteDepartmentCommand = new RelayCommand(ExecuteDeleteDepartmentCommand);
                return _deleteDepartmentCommand;
            }
        }



        public void ExecuteDeleteDepartmentCommand()
        {
            if (SelectedDepartment == null || SelectedDepartment.Id == 0) return;
            rep.Delete(SelectedDepartment);
            CurrentDepartment = null;
        }

        public Department SelectedDepartment
        {
            get { return _currentDepartment; }
            set
            {
                _currentDepartment = value;
                RaisePropertyChanged("selectedDepartment");
            }
        }
    }
}
