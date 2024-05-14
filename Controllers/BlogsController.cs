using BlogHeaven.DatabaseContext;
using BlogHeaven.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace BlogHeaven.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BlogsController : ControllerBase
    {
        private readonly BlogHeavenContext _context;

        public BlogsController(BlogHeavenContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Blog>> GetBlogs()
        {
            var blogs = _context.Blogs.ToList();
            return Ok(blogs);
        }

        [HttpGet("{id}")]
        public ActionResult<Blog> GetBlog(int id)
        {
            var blog = _context.Blogs.FirstOrDefault(b => b.BloggerId == id);
            if (blog == null)
            {
                return NotFound();
            }
            return Ok(blog);
        }
    }
}
