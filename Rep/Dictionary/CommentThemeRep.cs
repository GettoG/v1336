using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using v1336.Model;

namespace v1336.Rep.Dictionary
{
    public class CommentThemeRep : AbstractRep<CommentTheme>
    {
        public override IEnumerable<CommentTheme> GetAll()
        {
            using (var db = new DBContext())
            {
                return db.CommentThemes.ToList();
            }
        }

        public override CommentTheme GetById(int id)
        {
            using (var db = new DBContext())
            {
                return db.CommentThemes.FirstOrDefault(x => x.Id == id);
            }
        }

        public override void Add(CommentTheme obj)
        {
            using (var db = new DBContext())
            {
                db.CommentThemes.Add(obj);
                var entry = db.Entry(obj);
                entry.State = EntityState.Added;
                db.SaveChanges();
            }
        }

        public override void Update(CommentTheme obj)
        {
            using (var db = new DBContext())
            {
                db.CommentThemes.Attach(obj);
                var entry = db.Entry(obj);
                entry.State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        public override void Delete(CommentTheme obj)
        {
            using (var db = new DBContext())
            {
                db.CommentThemes.Attach(obj);
                var entry = db.Entry(obj);
                entry.State = EntityState.Deleted;
                db.SaveChanges();
            }
        }
    }
}
