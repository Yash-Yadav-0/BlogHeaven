using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlogHeaven.Entities
{
    public class Blog
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BloggerId { get; set; }
        [Required]
        [MaxLength(50)]
        public string BloggerName { get; set; }

        [MaxLength(200)]
        public string? BloggerDescription { get; set; }
        public int NumberOfBlogsByBlogger { get { return BlogsByBlogger.Count; } }
        public ICollection<BlogsByBlogger> BlogsByBlogger { get; set; } = new List<BlogsByBlogger>();
        public Blog(string bloggerName)
        {
            BloggerName = bloggerName;
        }
    }
}
