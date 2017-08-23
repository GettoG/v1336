using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace v1336.Model
{
    public class Customer : IDbObject
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        public Customer(string name)
        {
            Name = name;
        }

        public Customer()
        {
            
        }

        public override string ToString()
        {
            return Name;
        }
    }
    
}
