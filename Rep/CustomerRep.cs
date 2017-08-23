using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Windows.Documents;
using v1336.Model;

namespace v1336.Rep
{
    public class CustomerRep : IRep
    {
        private DBContext db;

        public CustomerRep()
        {
            db = new DBContext();
        }

        public ObservableCollection<Customer> GetAll()
        {
            db.Customers.Load();
            return db.Customers.Local;
        }

        IDbObject IRep.GetById(int id)
        {
            return GetById(id);
        }

        public void Add(IDbObject obj)
        {
            throw new System.NotImplementedException();
        }

        public void Update(IDbObject obj)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(IDbObject obj)
        {
            throw new System.NotImplementedException();
        }

        ObservableCollection<IDbObject> IRep.GetAll()
        {
            db.Customers.Load();
            return new ObservableCollection<IDbObject>(db.Customers.Local);
        }

        public Customer GetById(int id)
        {
            return db.Customers.FirstOrDefault(x=> x.Id == id);
        }

        public void Add(Customer obj)
        {
            db.Customers.Add(obj);
            db.SaveChanges();
        }

        public void Update(Customer obj)
        {
            db.Customers.Attach(obj);
            var entry = db.Entry(obj);
            entry.Property(e => e.Name).IsModified = true;
            db.SaveChanges();
            GetAll();
        }

        public void Delete(Customer obj)
        {
            db.Customers.Remove(obj);
            db.SaveChanges();
        }
    }
}
