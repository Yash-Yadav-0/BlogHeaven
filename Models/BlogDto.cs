namespace BlogHeaven.Models
{
    public class BlogDto
    {
        public int BloggerId { get; set; }
        public string BloggerName {  get; set; }=string.Empty;
        public string? BloggerDescription { get; set; }
        public int NumberOfBlogsByBlogger{ get { return BlogsByBlogger.Count; } }
        public ICollection<BlogsByBloggerDto> BlogsByBlogger { get; set; } = new List<BlogsByBloggerDto>();
    }
}
