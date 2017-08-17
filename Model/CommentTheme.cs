using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace v1336.Model
{
    public class CommentTheme
    {
        public int Id { get; set; }
        
        [Required]
        public string CommentThemeText { get; set; }
        public List<Department> Departments { get; set; }
    }
}
