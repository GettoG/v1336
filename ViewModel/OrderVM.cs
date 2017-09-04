using System.Collections.Generic;
using System.Linq;
using GalaSoft.MvvmLight;
using v1336.Model;
using v1336.Rep.Dictionary;
using v1336.Rep.Document;

namespace v1336.ViewModel
{
    public class OrderVM : ViewModelBase
    {
        OrderRep rep = new OrderRep();

        public List<Customer> Customers { get; set; }
        public List<Worker> Manager { get; set; }
        public List<Nomenclature> Nomenclatures { get; set; }
        public Order Order { get; set; } = new Order();

        public OrderVM(int id)
        {
            Customers = new CustomerRep().GetAll().ToList();
            Manager = new WorkerRep().GetAll().Where(x=>x.EmployeePostId == 1).ToList();
            Nomenclatures = new NomenclatureRep().GetAll().ToList();
            if (id != 0)
            {
                Order = rep.GetById(id);
            }
        }
      
        

    }
}