using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Windows.Documents;
using v1336.Model;
namespace v1336.Rep
{
    public class EmployeeRep : IRep<Employee>
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
