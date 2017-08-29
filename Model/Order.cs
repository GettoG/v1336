using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace v1336.Model
{
    public class Order
    {
        public int Id { get; set; }
        public int Count { get { return 1; } }
        public double Procent { get; set; } = 0;
        public int StatusId { get; set; }
        [ForeignKey("StatusId")]
        public Status Status { get; set; }
        public string Description { get; set; }
        [Required]
        public int Number { get; set; }
        [Required]
        public DateTime Date_b { get; set; }
        [Required]
        public DateTime Date_e { get; set; }
        public int ManagerPriority { get; set; } = 100;
        public int? AdminPriority { get; set; }
        [Required]
        public int ManagerId { get; set; }
        [ForeignKey("ManagerId")]
        public Manager Manager { get; set; }
        [Required]
        public int CustomerId { get; set; }
        [ForeignKey("CustomerId")]
        [Required]
        public Customer Customer { get; set; }
        public string Comment { get; set; }
        public List<OrderRow> Rows { get; set; } = new List<OrderRow>();
    }
}
