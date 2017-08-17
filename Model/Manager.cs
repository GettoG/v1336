using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace v1336.Model
{
    public class Manager
    {
        public int Id { get; set; }
        [Required]
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string FatherName { get; set; }
        public string Phone { get; set; }

        public override string ToString()
        {
            return $"{LastName} {FirstName} {FatherName} ({Phone})";
        }
    }
}
