using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using v1336.Model;

namespace v1336.Rep.Dictionary
{
    public class RoleRep : AbstractRep<Role>
    {
        public override IEnumerable<Role> GetAll()
        {
            using (var db = new DBContext())
            {
                return db.Roles.ToList();
            }
        }

        public override Role GetById(int id)
        {
            using (var db = new DBContext())
            {
                return db.Roles.FirstOrDefault(x => x.Id == id);
            }
        }

        public override void Add(Role obj)
        {
            using (var db = new DBContext())
            {
                db.Roles.Add(obj);
                var entry = db.Entry(obj);
                entry.State = EntityState.Added;
                db.SaveChanges();
            }
        }

        public override void Update(Role obj)
        {
            using (var db = new DBContext())
            {
                db.Roles.Attach(obj);
                var entry = db.Entry(obj);
                entry.State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        public override void Delete(Role obj)
        {
            using (var db = new DBContext())
            {
                db.Roles.Attach(obj);
                var entry = db.Entry(obj);
                entry.State = EntityState.Deleted;
                db.SaveChanges();
            }
        }
    }
}
