using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace v1336.Model
{
    public class Comment
    {
        public int Id { get; set; }

        public string Content { get; set; }
        [Required]
        public int CommentThemeId { get; set; }
        public CommentTheme CommentTheme { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    
    }
}
