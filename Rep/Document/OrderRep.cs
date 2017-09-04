using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Windows;
using v1336.Model;

namespace v1336.Rep.Document
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
                return db.Orders
                    .Include(x=> x.Rows)
                    .Include(x => x.Rows.Select(y => y.Nomenclature))
                    .Include(x => x.Rows.Select(y => y.Nomenclature.NomenclatureCategory))
                    . FirstOrDefault(x => x.Id == id);
            }
        }

        public override void Add(Order obj)
        {
            var rows = obj.Rows;
            using (var db = new DBContext())
            {
                obj.Rows = new List<OrderRow>();
                db.Orders.Add(obj);
                var entry = db.Entry(obj);
                entry.State = EntityState.Added;
                db.SaveChanges();
            }

            foreach (var row in rows)
            {
                row.OrderId = obj.Id;
            }
            new OrderRowRep().AddList(rows);
        }

        public override void Update(Order obj)
        {
            using (var db = new DBContext())
            {
                var rows = obj.Rows.ToList();
                rows.ForEach(x =>
                {
                    x.Nomenclature = null;
                    x.Order = null;
                });

                obj.Rows = new List<OrderRow>();
                db.Orders.Attach(obj);
                var entry = db.Entry(obj);
                entry.State = EntityState.Modified;
                db.SaveChanges();

                db.OrderRows.RemoveRange(db.OrderRows.Where(x => x.OrderId == obj.Id));
                db.SaveChanges();

                db.OrderRows.AddRange(rows);
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
