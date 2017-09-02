using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using v1336.Model;

namespace v1336.Rep
{
    public class OrderRep : AbstractRep<Order>
    {
        public override IEnumerable<Order> GetAll()
        {
            using (var db = new DBContext())
            {
                return db.Orders.ToList();
            }
        }

        public override Order GetById(int id)
        {
            using (var db = new DBContext())
            {
                return db.Orders.FirstOrDefault(x => x.Id == id);
            }
        }

        public override void Add(Order obj)
        {
            using (var db = new DBContext())
            {
                db.Orders.Add(obj);
                var entry = db.Entry(obj);
                entry.State = EntityState.Added;
                db.SaveChanges();
            }
        }

        public override void Update(Order obj)
        {
            using (var db = new DBContext())
            {
                db.Orders.Attach(obj);
                var entry = db.Entry(obj);
                entry.State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        public override void Delete(Order obj)
        {
            using (var db = new DBContext())
            {
                db.Orders.Attach(obj);
                var entry = db.Entry(obj);
                entry.State = EntityState.Deleted;
                db.SaveChanges();
            }
        }
    }
}
