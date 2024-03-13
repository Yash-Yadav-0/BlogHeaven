using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlogHeaven.Entities
{
    public class BlogsByBlogger
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BlogId { get; set; }
        [Required]
        [MaxLength(50)]
        public string BlogTitle { get; set; }
        public string BlogDescription { get; set; }
        [ForeignKey("BloggerId")]
        public Blog? Blog { get; set; }
        public int BloggerId { get; set; }
        public BlogsByBlogger(string? blogTitle)
        {
            BlogTitle = blogTitle;
        }
    }
}
