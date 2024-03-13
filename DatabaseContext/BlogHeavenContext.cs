using BlogHeaven.Entities;
using Microsoft.EntityFrameworkCore;

namespace BlogHeaven.DatabaseContext
{
    public class BlogHeavenContext : DbContext
    {
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<BlogsByBlogger> BlogsByBlogger { get; set; }

        public BlogHeavenContext(DbContextOptions<BlogHeavenContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Blog>().HasData(
                new Blog("Yash Yadav")
                {
                    BloggerId = 1,
                    BloggerDescription = "Tech Enthusiast",
                },
                new Blog("Dipesh Shah")
                {
                    BloggerId= 2,
                    BloggerDescription= "Travel Explorer",
                });
            modelBuilder.Entity<BlogsByBlogger>().HasData(
                new BlogsByBlogger("Nvidia Gpu")
                {
                    BlogId= 3,
                    BlogDescription= "Nvidia is 2x faster then AMD.",
                    BloggerId=1,
                },
                new BlogsByBlogger("Intel Downfall")
                {
                    BlogId=4,
                    BlogDescription= "Inter is expensive and uses more power.",
                    BloggerId=1,
                },
                new BlogsByBlogger("Hidden Gems in Southeast Asia")
                {
                    BlogId=5,
                    BlogDescription= "Discovering the less-explored wonders of Southeast Asia.",
                    BloggerId=2,
                }

                );
            base.OnModelCreating(modelBuilder);
        }

    }
}
