using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace v1336.Model
{
    public class NomenclatureCategory
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
