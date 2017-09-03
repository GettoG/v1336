using System.ComponentModel.DataAnnotations;

namespace v1336.Model
{
    public class Comment : IDbObject
    {
        public int Id { get; set; }
        [StringLength(256)]
        public string Content { get; set; }
        [Required]
        public int CommentThemeId { get; set; }
        public CommentTheme CommentTheme { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
