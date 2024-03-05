using System.ComponentModel.DataAnnotations;

namespace BlogHeaven.Models
{
    public class BlogsByBloggerUpdateDto
    {
        [Required]

        [MaxLength(30)]
        public string BlogTitle { get; set; } = string.Empty;
        [MaxLength(50)]
        public string BlogDescription { get; set; }
    }
}
