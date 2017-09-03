using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using v1336.Model;

namespace v1336.Rep.Dictionary
{
    public class DepartmentRep : AbstractRep< Department>
    {
        public override IEnumerable<Department> GetAll()
        {
            using (var db = new DBContext())
            {
                return db. Departments.ToList();
            }
        }

        public override Department GetById(int id)
        {
            using (var db = new DBContext())
            {
                return db. Departments.FirstOrDefault(x => x.Id == id);
            }
        }

        public override void Add(Department obj)
        {
            using (var db = new DBContext())
            {
                db. Departments.Add(obj);
                var entry = db.Entry(obj);
                entry.State = EntityState.Added;
                db.SaveChanges();
            }
        }

        public override void Update( Department obj)
        {
            using (var db = new DBContext())
            {
                db. Departments.Attach(obj);
                var entry = db.Entry(obj);
                entry.State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        public override void Delete(Department obj)
        {
            using (var db = new DBContext())
            {
                db. Departments.Attach(obj);
                var entry = db.Entry(obj);
                entry.State = EntityState.Deleted;
                db.SaveChanges();
            }
        }
    }
}
