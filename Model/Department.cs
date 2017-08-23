using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace v1336.Model
{
    public class Department : IDbObject
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        public List<Nomenclature> Nomenclatures { get; set; }
        public List<CommentTheme> CommentThemes { get; set; }

        public Department(string name)
        {
            Name = name;
        }

        public Department()
        {

        }

        public override string ToString()
        {
            return Name;
        }
    }
}
