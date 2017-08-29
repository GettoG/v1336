using System.Collections.Generic;
using System.Linq;
using GalaSoft.MvvmLight;
using v1336.Model;
using v1336.Rep;

namespace v1336.ViewModel
{
    public class OrderVM : ViewModelBase
    {
        OrderRep rep = new OrderRep();
        CustomerRep customerRep = new CustomerRep();
        public List<Customer> Customers { get; set; }
        public Order Order { get; set; }


        ManagerRep managerRep = new ManagerRep();
        public List<Manager> Managers { get; set; }

        public OrderVM(int id)
        {
            Customers = customerRep.GetAll().ToList();
            Managers = managerRep.GetAll().ToList();
            if (id != 0)
            {
                Order = rep.GetById(id);

            }
        }
      
        

    }
}