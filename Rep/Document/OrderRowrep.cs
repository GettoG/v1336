using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using v1336.Model;

namespace v1336.Rep.Document
{
    public class OrderRowRep : AbstractRep<OrderRow>
    {
        public override IEnumerable<OrderRow> GetAll()
        {
            using (var db = new DBContext())
            {
                return db.OrderRows.ToList();
            }
        }

        public override OrderRow GetById(int id)
        {
            using (var db = new DBContext())
            {
                return db.OrderRows.FirstOrDefault(x => x.Id == id);
            }
        }

        public override void Add(OrderRow obj)
        {
            using (var db = new DBContext())
            {
                db.OrderRows.Add(obj);
                var entry = db.Entry(obj);
                entry.State = EntityState.Added;
                db.SaveChanges();
            }
        }

        public override void Update(OrderRow obj)
        {
            using (var db = new DBContext())
            {
                db.OrderRows.Attach(obj);
                var entry = db.Entry(obj);
                entry.State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        public override void Delete(OrderRow obj)
        {
            using (var db = new DBContext())
            {
                db.OrderRows.Attach(obj);
                var entry = db.Entry(obj);
                entry.State = EntityState.Deleted;
                db.SaveChanges();
            }
        }
    }
}
