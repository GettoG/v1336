using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using v1336.Model;

namespace v1336.Rep.Document
{
    public class CommentRep : AbstractRep<Comment>
    {
        public override IEnumerable<Comment> GetAll()
        {
            using (var db = new DBContext())
            {
                return db.Comments.ToList();
            }
        }

        public override Comment GetById(int id)
        {
            using (var db = new DBContext())
            {
                return db.Comments.FirstOrDefault(x => x.Id == id);
            }
        }

        public override void Add(Comment obj)
        {
            using (var db = new DBContext())
            {
                db.Comments.Add(obj);
                var entry = db.Entry(obj);
                entry.State = EntityState.Added;
                db.SaveChanges();
            }
        }

        public override void Update(Comment obj)
        {
            using (var db = new DBContext())
            {
                db.Comments.Attach(obj);
                var entry = db.Entry(obj);
                entry.State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        public override void Delete(Comment obj)
        {
            using (var db = new DBContext())
            {
                db.Comments.Attach(obj);
                var entry = db.Entry(obj);
                entry.State = EntityState.Deleted;
                db.SaveChanges();
            }
        }
    }
}
