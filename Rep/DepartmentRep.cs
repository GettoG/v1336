using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Windows.Documents;
using v1336.Model;

namespace v1336.Rep
{
    public class DepartmentRep : IRep<Department>
    {
        private DBContext db;

        public DepartmentRep()
        {
            db = new DBContext();
        }

        public ObservableCollection<Department> GetAll()
        {
            db.Departments.Load();
            return db.Departments.Local;
        }

        public Department GetById(int id)
        {
            return db.Departments.FirstOrDefault(x => x.Id == id);
        }

        public void Add(Department obj)
        {
            db.Departments.Add(obj);
            db.SaveChanges();
        }

        public void Update(Department obj)
        {
            db.Departments.Attach(obj);
            var entry = db.Entry(obj);
            entry.Property(e => e.Name).IsModified = true;
            db.SaveChanges();
            GetAll();
        }

        public void Delete(Department obj)
        {
            db.Departments.Remove(obj);
            db.SaveChanges();
        }
    }
}
