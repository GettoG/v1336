using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace v1336.Model
{
    public class Nomenclature : IDbObject
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        public int NomenclatureCategoryId { get; set; }
        public NomenclatureCategory NomenclatureCategory { get; set; }

        public List<Department> Departments { get; set; }
  
        public Nomenclature(string name)
        {
            Name = name;
        }

        public Nomenclature()
        {

        }

        public override string ToString()
        {
            return Name;
        }
    }
}
