using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace v1336.Model
{
    public class CommentTheme : AbstartDictionaryObject
    {
        public List<Department> Departments { get; set; }
    }
}
