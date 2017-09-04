using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace v1336.Model
{
    public class Worker : IDbObject
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string LastName { get; set; }
        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }
        [StringLength(50)]
        public string FatherName { get; set; }
        [StringLength(20)]
        public string Phone { get; set; }
        [Required]
        public int EmployeePostId { get; set; }
        public WorkerPost EmployeePost { get; set; }

        [Required]
        public int DepartmentId { get; set; }
        public Department Department { get; set; }

        public override string ToString()
        {
            return $"{LastName} {FirstName} {FatherName} ({Phone})";
        }
    }
}
