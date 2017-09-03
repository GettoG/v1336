using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using v1336.Model;

namespace v1336.Rep.Dictionary
{
    public class NomenclatureRep : AbstractRep<Nomenclature>
    {
        public override IEnumerable<Nomenclature> GetAll()
        {
            using (var db = new DBContext())
            {
                return db.Nomenclatures.ToList();
            }
        }

        public override Nomenclature GetById(int id)
        {
            using (var db = new DBContext())
            {
                return db.Nomenclatures.FirstOrDefault(x => x.Id == id);
            }
        }

        public override void Add(Nomenclature obj)
        {
            using (var db = new DBContext())
            {
                db.Nomenclatures.Add(obj);
                var entry = db.Entry(obj);
                entry.State = EntityState.Added;
                db.SaveChanges();
            }
        }

        public override void Update(Nomenclature obj)
        {
            using (var db = new DBContext())
            {
                db.Nomenclatures.Attach(obj);
                var entry = db.Entry(obj);
                entry.State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        public override void Delete(Nomenclature obj)
        {
            using (var db = new DBContext())
            {
                db.Nomenclatures.Attach(obj);
                var entry = db.Entry(obj);
                entry.State = EntityState.Deleted;
                db.SaveChanges();
            }
        }
    }
}
