using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using v1336.Model;

namespace v1336.Rep.Dictionary
{
    public class UserRep : AbstractRep<User>
    {
        public override IEnumerable<User> GetAll()
        {
            using (var db = new DBContext())
            {
                return db.Users.ToList();
            }
        }

        public override User GetById(int id)
        {
            using (var db = new DBContext())
            {
                return db.Users.FirstOrDefault(x => x.Id == id);
            }
        }

        public override void Add(User obj)
        {
            using (var db = new DBContext())
            {
                db.Users.Add(obj);
                var entry = db.Entry(obj);
                entry.State = EntityState.Added;
                db.SaveChanges();
            }
        }

        public override void Update(User obj)
        {
            using (var db = new DBContext())
            {
                db.Users.Attach(obj);
                var entry = db.Entry(obj);
                entry.State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        public override void Delete(User obj)
        {
            using (var db = new DBContext())
            {
                db.Users.Attach(obj);
                var entry = db.Entry(obj);
                entry.State = EntityState.Deleted;
                db.SaveChanges();
            }
        }
    }
}
