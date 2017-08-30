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
      

        public EmployeeRep()
        {
         
        }

        public ObservableCollection<Employee> GetAll()
        {
            using (var db = new DBContext())
            {
                db.Employees.Include("Department").Load();
                return db.Employees.Local;
            }
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
            using (var db = new DBContext())
            {
                var item = db.Employees.First(c => c.Id == obj.Id);
                db.Employees.Remove(item);
                db.SaveChanges();
            }
        }

        ObservableCollection<IDbObject> IRep.GetAll()
        {
            using (var db = new DBContext())
            {
                return new ObservableCollection<IDbObject>(db.Employees.Include("Department"));
            }
           
        }

        public Employee GetById(int id)
        {
            using (var db = new DBContext())
            {
                return db.Employees.FirstOrDefault(x => x.Id == id);
            }
            
        }

        public void Add(Employee obj)
        {
            using (var db = new DBContext())
            {
                db.Employees.Add(obj);
                db.Entry(obj).State = EntityState.Added;
                db.SaveChanges();
            }

           
        }

        public void Update(Employee obj)
        {
            using (var db = new DBContext())
            {
                db.Employees.Attach(obj);
                var entry = db.Entry(obj);
                entry.Property(e => e.DepartmentId).IsModified = true;
                entry.Property(e => e.FatherName).IsModified = true;
                entry.Property(e => e.LastName).IsModified = true;
                entry.Property(e => e.FirstName).IsModified = true;
                entry.Property(e => e.Phone).IsModified = true;
                db.SaveChanges();
            }
           
        }

        public void Delete(Employee obj)
        {
            using (var db = new DBContext())
            {
                db.Employees.Remove(obj);
                db.SaveChanges();
            }
          
        }
    }
}
