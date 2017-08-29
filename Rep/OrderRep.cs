using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using v1336.Model;

namespace v1336.Rep
{
    public class OrderRep 
    {
        private DBContext db;

        public OrderRep()
        {
            db = new DBContext();
        }

        public List<Order> GetAll()
        {
            return db.Orders
                .Include("Manager")
                .Include("Status")
                .Include("Customer")
                .ToList();

        }

        public Order GetById(int id)
        {
            var res = db.Orders
                .Include("Manager")
                .Include("Status")
                .Include("Customer")
                .Include("Rows")
                .Include("Rows.Nomenclature")
                .Include("Rows.Nomenclature.Departments")
                .FirstOrDefault(x => x.Id == id);

            return res;
        }

        public void Add(Order obj)
        {
            db.Orders.Add(obj);
            db.SaveChanges();
        }

        public void Update(Order obj)
        {
            db.Orders.Attach(obj);
            db.SaveChanges();
        }

        public void Delete(Order obj)
        {
            db.Orders.Remove(obj);
            db.SaveChanges();
        }
    }
}
