using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace v1336.Model
{
    public class Nomenclature
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int NomenclatureCategoryId { get; set; }
        public NomenclatureCategory NomenclatureCategory { get; set; }
        [Required]
        public List<Department> Departments { get; set; }
    }
}
