using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using v1336.Model;

namespace v1336.Rep.Document
{
    public class OrderRowRep : AbstractRep<OrderRow>
    {

        public void DeleteAll(IEnumerable<OrderRow> rows)
        {
            using (var db = new DBContext())
            {
                foreach (var row in rows)
                {
                    db.OrderRows.Attach(row);
                    var entry = db.Entry(row);
                    entry.State = EntityState.Deleted;
                }
                db.SaveChanges();
            }
        }

        public void AddList(IEnumerable<OrderRow> rows)
        {
            using (var db = new DBContext())
            {
                foreach (var row in rows)
                {
                    row.Nomenclature = null;
                    db.OrderRows.Add(row);
                    var entry = db.Entry(row);
                    entry.State = EntityState.Added;
                }
                db.SaveChanges();
            }
        }
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
