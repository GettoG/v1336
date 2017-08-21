using System.Collections.Generic;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using v1336.Rep;
using v1336.Model;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Windows.Input;
using v1336.View;

namespace v1336.ViewModel
{
    class EmployeesVM : ViewModelBase
    {
        private EmployeeRep rep;
        public EmployeesVM()
        {
            rep = new EmployeeRep();
            Departments = new DepartmentRep().GetAll();
        }

        public ObservableCollection<Department> Departments { get; set; }

        Employee _currentEmployee;
        public Employee CurrentEmployee
        {
            get
            {
                if (_currentEmployee == null)
                    _currentEmployee = new Employee();
                return _currentEmployee;
            }
            set
            {
           
                _currentEmployee = value;
                RaisePropertyChanged("CurrentEmployee");
            }
        }

        ObservableCollection<Employee> _employees;
        public ObservableCollection<Employee> Employees
        {
            get
            {
                if (_employees == null)
                {
                    _employees = rep.GetAll();
                    _employees.CollectionChanged += UpdateEmployee;
                }
                return _employees;
            }
        }

        public void UpdateEmployee(object sender, NotifyCollectionChangedEventArgs e)
        {
            RaisePropertyChanged("Employees");
        }

        RelayCommand _addEmployeeCommand;
        public ICommand AddEmployee
        {
            get
            {
                if (_addEmployeeCommand == null)
                    _addEmployeeCommand = new RelayCommand(ExecuteAddEmployeeCommand, CanExecuteAddEmployeeCommand);
                return _addEmployeeCommand;
            }
        }
        public void ExecuteAddEmployeeCommand()
        {
            rep.Add(CurrentEmployee);
            CurrentEmployee = null;
        }
        public bool CanExecuteAddEmployeeCommand()
        {
            return true; //!string.IsNullOrEmpty(CurrentEmployee.LastName) && !string.IsNullOrEmpty(CurrentEmployee.FirstName) && !string.IsNullOrEmpty(CurrentEmployee.FatherName);
        }

        private RelayCommand _deleteEmployeeCommand;
        public RelayCommand DeleteEmployee
        {
            get
            {
                if (_deleteEmployeeCommand == null)
                    _deleteEmployeeCommand = new RelayCommand(ExecuteDeleteEmployeeCommand);
                return _deleteEmployeeCommand;
            }
        }



        public void ExecuteDeleteEmployeeCommand()
        {
            if (SelectedEmployee == null || SelectedEmployee.Id == 0) return;
            rep.Delete(SelectedEmployee);
            CurrentEmployee = null;
        }

        public Employee SelectedEmployee
        {
            get { return _currentEmployee; }
            set
            {
                _currentEmployee = value;
                RaisePropertyChanged("selectedEmployee");
            }
        }
    }
}
