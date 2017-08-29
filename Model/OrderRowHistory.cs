using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace v1336.Model
{
    class OrderRowHistory
    {
        public int Id { get; set; }
        [Required]
        public int OrderRowId { get; set; }
        public OrderRow OrderRow { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
        public double Procent { get; set; }
        [Required]
        public int StatusId { get; set; }
        public  Status Status { get; set; }
        public  int? CommentId { get; set; }
        //public Bop Com { get; set; }
    }
}
