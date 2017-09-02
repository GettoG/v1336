using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using v1336.Model;

namespace v1336.Rep
{
    public class EmployeeRep : AbstractRep<Employee>
    {
        public override IEnumerable<Employee> GetAll()
        {
            using (var db = new DBContext())
            {
                return db.Employees.ToList();
            }
        }

        public override Employee GetById(int id)
        {
            using (var db = new DBContext())
            {
                return db.Employees.FirstOrDefault(x => x.Id == id);
            }
        }

        public override void Add(Employee obj)
        {
            using (var db = new DBContext())
            {
                db.Employees.Add(obj);
                var entry = db.Entry(obj);
                entry.State = EntityState.Added;
                db.SaveChanges();
            }
        }

        public override void Update(Employee obj)
        {
            using (var db = new DBContext())
            {
                db.Employees.Attach(obj);
                var entry = db.Entry(obj);
                entry.State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        public override void Delete(Employee obj)
        {
            using (var db = new DBContext())
            {
                db.Employees.Attach(obj);
                var entry = db.Entry(obj);
                entry.State = EntityState.Deleted;
                db.SaveChanges();
            }
        }
    }
}
