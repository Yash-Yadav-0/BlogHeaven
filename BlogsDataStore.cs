using BlogHeaven.Models;

namespace BlogHeaven
{
    public class BlogsDataStore
    {
        public List<BlogDto>Blogs { get; set; }
        public static BlogsDataStore Current { get; set; } = new BlogsDataStore();
        public BlogsDataStore()
        {
            Blogs = new List<BlogDto>()
            {
                new BlogDto()
                {
                    BloggerId = 1,
                    BloggerName="Yash Yadav",
                    BloggerDescription="Tech Enthusiast",
                    BlogsByBlogger =new List<BlogsByBloggerDto>()
                    {
                        new BlogsByBloggerDto()
                        {
                            BlogId=1,
                            BlogTitle="Nvidia Cards",
                            BlogDescription ="Nvidia is 2x faster then AMD."
                        },
                        new BlogsByBloggerDto()
                        {
                            BlogId=2,
                            BlogTitle="Intel Downfall",
                            BlogDescription="Inter is expensive and uses more power."
                        }
                    }
                },
                new BlogDto()
                {
                    BloggerId = 2,
                    BloggerName = "Alicia Smith",
                    BloggerDescription = "Gaming Guru",
                    BlogsByBlogger = new List<BlogsByBloggerDto>()
                    { 
                        new BlogsByBloggerDto()
                        {
                           BlogId = 3,
                           BlogTitle = "Best Gaming Peripherals",
                           BlogDescription = "A detailed guide to choosing the perfect gaming peripherals."
                        },
                        new BlogsByBloggerDto()
                        {
                           BlogId = 4,
                           BlogTitle = "Console vs PC Gaming",
                           BlogDescription = "Debunking myths and helping you decide between console and PC gaming."
                         }
                    }
                },
                new BlogDto()
                {
                    BloggerId=3,
                    BloggerName="Ranjit Chaudhary",
                    BloggerDescription="Travel Explorer",
                    BlogsByBlogger=new List<BlogsByBloggerDto>()
                    {
                        new BlogsByBloggerDto()
                        {
                            BlogId = 5,
                            BlogTitle = "Hidden Gems in Southeast Asia",
                            BlogDescription = "Discovering the less-explored wonders of Southeast Asia."
                        },
                        new BlogsByBloggerDto()
                        {
                            BlogId=6,
                            BlogTitle="Budget Backpacking Tips",
                            BlogDescription="Tips and tricks for backpacking on a budget without compromising the experience."
                        }
                    }
                }


            };
        }
    }
}
