using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Windows.Documents;
using v1336.Model;

namespace v1336.Rep
{
    class NomenclatureRep : IRep<Nomenclature>
    {
        private DBContext db;

        public NomenclatureRep()
        {
            db = new DBContext();
        }

        public ObservableCollection<Nomenclature> GetAll()
        {
            db.Nomenclatures.Load();
            return db.Nomenclatures.Local;
        }

        public Nomenclature GetById(int id)
        {
            return db.Nomenclatures.FirstOrDefault(x=> x.Id == id);
        }

        public void Add(Nomenclature obj)
        {
            db.Nomenclatures.Add(obj);
            db.SaveChanges();
        }

        public void Update(Nomenclature obj)
        {
            db.Nomenclatures.Attach(obj);
            var entry = db.Entry(obj);
            entry.Property(e => e.Name).IsModified = true;
            db.SaveChanges();
            GetAll();
        }

        public void Delete(Nomenclature obj)
        {
            db.Nomenclatures.Remove(obj);
            db.SaveChanges();
        }
    }
}
