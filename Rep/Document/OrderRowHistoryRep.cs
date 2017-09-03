using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using v1336.Model;

namespace v1336.Rep.Document
{
    public class OrderRowHistoryRep : AbstractRep<OrderRowHistory>
    {
        public override IEnumerable<OrderRowHistory> GetAll()
        {
            using (var db = new DBContext())
            {
                return db.OrderRowHistorys.ToList();
            }
        }

        public override OrderRowHistory GetById(int id)
        {
            using (var db = new DBContext())
            {
                return db.OrderRowHistorys.FirstOrDefault(x => x.Id == id);
            }
        }

        public override void Add(OrderRowHistory obj)
        {
            using (var db = new DBContext())
            {
                db.OrderRowHistorys.Add(obj);
                var entry = db.Entry(obj);
                entry.State = EntityState.Added;
                db.SaveChanges();
            }
        }

        public override void Update(OrderRowHistory obj)
        {
            using (var db = new DBContext())
            {
                db.OrderRowHistorys.Attach(obj);
                var entry = db.Entry(obj);
                entry.State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        public override void Delete(OrderRowHistory obj)
        {
            using (var db = new DBContext())
            {
                db.OrderRowHistorys.Attach(obj);
                var entry = db.Entry(obj);
                entry.State = EntityState.Deleted;
                db.SaveChanges();
            }
        }
    }
}
