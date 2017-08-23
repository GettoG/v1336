using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Windows.Documents;
using v1336.Model;
namespace v1336.Rep
{
    public class EmployeeRep : IRep
    {
        private DBContext db;

        public EmployeeRep()
        {
            db = new DBContext();
        }

        public ObservableCollection<Employee> GetAll()
        {
            db.Employees.Load();
            return db.Employees.Local;
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
            throw new System.NotImplementedException();
        }

        public Employee GetById(int id)
        {
            return db.Employees.FirstOrDefault(x => x.Id == id);
        }

        public void Add(Employee obj)
        {
            db.Employees.Add(obj);
            db.SaveChanges();
        }

        public void Update(Employee obj)
        {
            db.Employees.Attach(obj);
            var entry = db.Entry(obj);
            entry.Property(e => e.FirstName).IsModified = true;
            db.SaveChanges();
        }

        public void Delete(Employee obj)
        {
            db.Employees.Remove(obj);
            db.SaveChanges();
        }
    }
}
