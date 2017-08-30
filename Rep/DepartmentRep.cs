using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Windows.Documents;
using v1336.Model;

namespace v1336.Rep
{
    public class DepartmentRep : IRep
    {
        private DBContext db;

        public DepartmentRep()
        {
            db = new DBContext();
        }

        

        IDbObject IRep.GetById(int id)
        {
            return GetById(id);
        }

        public void Add(IDbObject obj)
        {
            
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
            db.Departments.Load();
            return new ObservableCollection<IDbObject>(db.Departments.Local);
        }


        public List<Department> GetAll()
        {
            return db.Departments.ToList();
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
