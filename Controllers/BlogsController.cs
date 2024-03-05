using BlogHeaven.Models;
using Microsoft.AspNetCore.Mvc;


namespace BlogHeaven.Controllers
{
    [ApiController]
    [Route("api/blogs")]
    public class BlogsController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<BlogDto>> GetBlogs()
        {
            return Ok(BlogsDataStore.Current.Blogs);
        }

        // GET api/<BlogsController>/5
        [HttpGet("id={id}")]
        public ActionResult<BlogDto> GetBlog(int id)
        {
            var blogToReturn = BlogsDataStore.Current.Blogs.FirstOrDefault(b=> b.BloggerId == id);
            if (blogToReturn == null)
            {
                return NotFound();
            }
            return Ok(blogToReturn);
        }

        // POST api/<BlogsController>
        
    }
}
