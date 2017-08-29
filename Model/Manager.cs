using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace v1336.Model
{
    public class Manager : IDbObject
    {
        public int Id { get; set; }
        [Required]
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string FatherName { get; set; }
        public string Phone { get; set; }

        public string FullName
        {
            get
            {
                string res = LastName;
                if (!string.IsNullOrEmpty(FirstName))
                {
                    res += " " + FirstName[0] + ".";
                }
                if (!string.IsNullOrEmpty(FirstName))
                {
                    res += " " + FatherName[0] + ".";
                }
                return res;
            }
        }

        public override string ToString()
        {
            return $"{LastName} {FirstName} {FatherName} ({Phone})";
        }
    }
}
