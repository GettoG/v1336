using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace v1336.Model
{
    public class User : AbstartDictionaryObject
    {
        [Required]
        [StringLength(50)]
        public string Password { get; set; }

        public List<Role> Roles { get; set; }

    }
}
