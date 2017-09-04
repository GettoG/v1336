using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using v1336.Model;

namespace v1336.Rep.Dictionary
{
    public class WorkerPostRep : AbstractRep<WorkerPost>
    {
        public override IEnumerable<WorkerPost> GetAll()
        {
            using (var db = new DBContext())
            {
                return db.WorkerPosts.ToList();
            }
        }

        public override WorkerPost GetById(int id)
        {
            using (var db = new DBContext())
            {
                return db.WorkerPosts.FirstOrDefault(x => x.Id == id);
            }
        }

        public override void Add(WorkerPost obj)
        {
            using (var db = new DBContext())
            {
                db.WorkerPosts.Add(obj);
                var entry = db.Entry(obj);
                entry.State = EntityState.Added;
                db.SaveChanges();
            }
        }

        public override void Update(WorkerPost obj)
        {
            using (var db = new DBContext())
            {
                db.WorkerPosts.Attach(obj);
                var entry = db.Entry(obj);
                entry.State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        public override void Delete(WorkerPost obj)
        {
            using (var db = new DBContext())
            {
                db.WorkerPosts.Attach(obj);
                var entry = db.Entry(obj);
                entry.State = EntityState.Deleted;
                db.SaveChanges();
            }
        }
    }
}
