using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using v1336.Model;

namespace v1336.Rep
{
    public class CustomerRep : AbstractRep<Customer>
    {
        public override IEnumerable<Customer> GetAll()
        {
            using (var db = new DBContext())
            {
                return db.Customers.ToList();
            }
        }

        public override Customer GetById(int id)
        {
            using (var db = new DBContext())
            {
                return db.Customers.FirstOrDefault(x => x.Id == id);
            }
        }

        public override void Add(Customer obj)
        {
            using (var db = new DBContext())
            {
                db.Customers.Add(obj);
                var entry = db.Entry(obj);
                entry.State = EntityState.Added;
                db.SaveChanges();
            }
        }

        public override void Update(Customer obj)
        {
            using (var db = new DBContext())
            {
                db.Customers.Attach(obj);
                var entry = db.Entry(obj);
                entry.State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        public override void Delete(Customer obj)
        {
            using (var db = new DBContext())
            {
                db.Customers.Attach(obj);
                var entry = db.Entry(obj);
                entry.State = EntityState.Deleted;
                db.SaveChanges();
            }
        }
    }
}
