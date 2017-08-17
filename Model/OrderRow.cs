using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace v1336.Model
{
    public class OrderRow
    {
        public int Id { get; set; }
        [Required]
        public int OrderId { get; set; }
        public Order Order { get; set; }
        public int CommentId { get; set; }
        public Comment Comment { get; set; }
        [Required]
        public int NomenclatureId { get; set; }
        public Nomenclature Nomenclature { get; set; }
        [Required]
        public double Quantity { get; set; }
        
        public List<Employee> Employees { get; set; }
        public double Procent { get; set; }
    }
}
