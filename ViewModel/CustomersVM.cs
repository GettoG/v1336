using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using v1336.Rep;
using v1336.Model;

namespace v1336.ViewModel
{
    public class CustomersVM : ViewModelBase
    {
        private CustomerRep rep;
        public CustomersVM()
        {
            rep = new CustomerRep();
        }

        Customer _currentCustomer;
        public Customer CurrentCustomer
        {
            get
            {
                if (_currentCustomer == null)
                    _currentCustomer = new Customer();
                return _currentCustomer;
            }
            set
            {
                _currentCustomer = value;
                RaisePropertyChanged("CurrentCustomer");
            }
        }

        private ObservableCollection<Customer> _customers;
        public ObservableCollection<Customer> Customers
        {
            get
            {
                if (_customers == null)
                {
                    _customers = new ObservableCollection<Customer>(rep.GetAll());
                    _customers.CollectionChanged += UpdateCustomer;
                }
                return _customers;
            }
          
        }

        private void UpdateCustomer(object sender, NotifyCollectionChangedEventArgs e)
        {
            RaisePropertyChanged("Customers");
        }

        RelayCommand _addCustomerCommand;
        public RelayCommand AddCustomer
        {
            get
            {
                if (_addCustomerCommand == null)
                    _addCustomerCommand = new RelayCommand(ExecuteAddCustomerCommand, CanExecuteAddCustomerCommand);
                return _addCustomerCommand;
            }
        }
        public void ExecuteAddCustomerCommand()
        {
            rep.Add(CurrentCustomer);
            CurrentCustomer = null;
        }
        public bool CanExecuteAddCustomerCommand()
        {
            return !string.IsNullOrEmpty(CurrentCustomer.Name);
            /*if (string.IsNullOrEmpty(CurrentCustomer.Name))
                return false;
            return true;*/
        }

        private RelayCommand _deleteCustomerCommand;
        public RelayCommand DeleteCustomer
        {
            get
            {
                if (_deleteCustomerCommand == null)
                    _deleteCustomerCommand = new RelayCommand(ExecuteDeleteCustomerCommand);
                return _deleteCustomerCommand;
            }
        }

      

        public void ExecuteDeleteCustomerCommand()
        {
            if(SelectedCustomer  == null || SelectedCustomer.Id == 0) return;
            rep.Delete(SelectedCustomer);
            CurrentCustomer = null;
        }

        public Customer SelectedCustomer
        {
            get { return _currentCustomer; }
            set
            {
                _currentCustomer = value;
                RaisePropertyChanged("selectedCustomer");
            }
        }
    }
}
