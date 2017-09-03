using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using v1336.Model;

namespace v1336.Rep.Dictionary
{
    public class NomenclatureCategoryRep : AbstractRep<NomenclatureCategory>
    {
        public override IEnumerable<NomenclatureCategory> GetAll()
        {
            using (var db = new DBContext())
            {
                return db.NomenclatureCategorys.ToList();
            }
        }

        public override NomenclatureCategory GetById(int id)
        {
            using (var db = new DBContext())
            {
                return db.NomenclatureCategorys.FirstOrDefault(x => x.Id == id);
            }
        }

        public override void Add(NomenclatureCategory obj)
        {
            using (var db = new DBContext())
            {
                db.NomenclatureCategorys.Add(obj);
                var entry = db.Entry(obj);
                entry.State = EntityState.Added;
                db.SaveChanges();
            }
        }

        public override void Update(NomenclatureCategory obj)
        {
            using (var db = new DBContext())
            {
                db.NomenclatureCategorys.Attach(obj);
                var entry = db.Entry(obj);
                entry.State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        public override void Delete(NomenclatureCategory obj)
        {
            using (var db = new DBContext())
            {
                db.NomenclatureCategorys.Attach(obj);
                var entry = db.Entry(obj);
                entry.State = EntityState.Deleted;
                db.SaveChanges();
            }
        }
    }
}
