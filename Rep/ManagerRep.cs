using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using v1336.Model;

namespace v1336.Rep
{
    public class ManagerRep : AbstractRep<Manager>
    {
        public override IEnumerable<Manager> GetAll()
        {
            using (var db = new DBContext())
            {
                return db.Managers.ToList();
            }
        }

        public override Manager GetById(int id)
        {
            using (var db = new DBContext())
            {
                return db.Managers.FirstOrDefault(x => x.Id == id);
            }
        }

        public override void Add(Manager obj)
        {
            using (var db = new DBContext())
            {
                db.Managers.Add(obj);
                var entry = db.Entry(obj);
                entry.State = EntityState.Added;
                db.SaveChanges();
            }
        }

        public override void Update(Manager obj)
        {
            using (var db = new DBContext())
            {
                db.Managers.Attach(obj);
                var entry = db.Entry(obj);
                entry.State = EntityState.Modified; 
                db.SaveChanges();
            }
        }

        public override void Delete(Manager obj)
        {
            using (var db = new DBContext())
            {
                db.Managers.Attach(obj);
                var entry = db.Entry(obj);
                entry.State = EntityState.Deleted;
                db.SaveChanges();
            }
        }
    }
}
