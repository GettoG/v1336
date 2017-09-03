using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace v1336.Model
{
    public class Role : AbstartDictionaryObject
    {
        public List<User> Users { get; set; }
    }
}
