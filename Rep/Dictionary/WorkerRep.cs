using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using v1336.Model;

namespace v1336.Rep.Dictionary
{
    public class WorkerRep : AbstractRep<Worker>
    {
        public override IEnumerable<Worker> GetAll()
        {
            using (var db = new DBContext())
            {
                return db.Workers.ToList();
            }
        }

        public override Worker GetById(int id)
        {
            using (var db = new DBContext())
            {
                return db.Workers.FirstOrDefault(x => x.Id == id);
            }
        }

        public override void Add(Worker obj)
        {
            using (var db = new DBContext())
            {
                db.Workers.Add(obj);
                var entry = db.Entry(obj);
                entry.State = EntityState.Added;
                db.SaveChanges();
            }
        }

        public override void Update(Worker obj)
        {
            using (var db = new DBContext())
            {
                db.Workers.Attach(obj);
                var entry = db.Entry(obj);
                entry.State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        public override void Delete(Worker obj)
        {
            using (var db = new DBContext())
            {
                db.Workers.Attach(obj);
                var entry = db.Entry(obj);
                entry.State = EntityState.Deleted;
                db.SaveChanges();
            }
        }
    }
}
