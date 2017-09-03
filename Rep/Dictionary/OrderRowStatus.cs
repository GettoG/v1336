using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using v1336.Model;

namespace v1336.Rep.Dictionary
{
    public class OrderRowStatusRep : AbstractRep<OrderRowStatus>
    {
        public override IEnumerable<OrderRowStatus> GetAll()
        {
            using (var db = new DBContext())
            {
                return db.OrderRowStatus.ToList();
            }
        }

        public override OrderRowStatus GetById(int id)
        {
            using (var db = new DBContext())
            {
                return db.OrderRowStatus.FirstOrDefault(x => x.Id == id);
            }
        }

        public override void Add(OrderRowStatus obj)
        {
            using (var db = new DBContext())
            {
                db.OrderRowStatus.Add(obj);
                var entry = db.Entry(obj);
                entry.State = EntityState.Added;
                db.SaveChanges();
            }
        }

        public override void Update(OrderRowStatus obj)
        {
            using (var db = new DBContext())
            {
                db.OrderRowStatus.Attach(obj);
                var entry = db.Entry(obj);
                entry.State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        public override void Delete(OrderRowStatus obj)
        {
            using (var db = new DBContext())
            {
                db.OrderRowStatus.Attach(obj);
                var entry = db.Entry(obj);
                entry.State = EntityState.Deleted;
                db.SaveChanges();
            }
        }
    }
}
