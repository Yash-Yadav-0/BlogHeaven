using BlogHeaven.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace BlogHeaven.Controllers
{
    [Route("api/blogs/{bloggerId}/BlogsByBlogger/")]
    [ApiController]
    public class BlogsByBloggerController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<BlogDto>>GetBlogData(int bloggerId)
        {
            var blog = BlogsDataStore.Current.Blogs.FirstOrDefault(b=>b.BloggerId ==bloggerId);
            if (blog == null)
            {
                return NotFound();
            }
            return Ok(blog.BlogsByBlogger);
        }
        [HttpGet("{blogId}",Name = "GetBlogByBlogger")]
       // [Produces("application/json")]
        public ActionResult<BlogsByBloggerDto>GetBlogByBlogger( int bloggerId, int blogId)
        {
            var blog= BlogsDataStore.Current.Blogs.FirstOrDefault(b => b.BloggerId== bloggerId);
            if(blog == null)
            {
                return NotFound();
            }
            var blogByBlogger = blog.BlogsByBlogger.FirstOrDefault(c=>c.BlogId==blogId);

            if (blogByBlogger == null) 
                return NotFound(); 
            return Ok(blogByBlogger);
        }

        [HttpPost]
        public ActionResult<BlogsByBloggerDto> CreateBlogsByBlogger(int bloggerId,BlogsByBloggerForCreationDto blogsByBlogger)
        {

            var blog =BlogsDataStore.Current.Blogs.FirstOrDefault(c=>c.BloggerId==bloggerId);
            if(blog == null)
                return NotFound();

            var maxBlogsByBloggerId = BlogsDataStore.Current.Blogs.SelectMany(c => c.BlogsByBlogger).Max(p => p.BlogId);

            var finalBlogsByBlogger = new BlogsByBloggerDto()
            {
                BlogId = ++maxBlogsByBloggerId,
                BlogTitle = blogsByBlogger.BlogTitle,
                BlogDescription = blogsByBlogger.BlogDescription,
            };
            blog.BlogsByBlogger.Add(finalBlogsByBlogger);

            return CreatedAtRoute("GetBlogByBlogger",
                new
                {
                    bloggerId = bloggerId,
                    blogId = finalBlogsByBlogger.BlogId,
                },
                finalBlogsByBlogger);
        }
        [HttpPut("{blogId}")]
        public ActionResult UpdateBlogsByBlogger(int bloggerId,
            int blogId,BlogsByBloggerForCreationDto blogsByBlogger)
        {
            var blog=BlogsDataStore.Current.Blogs.FirstOrDefault(c=>c.BloggerId==bloggerId);
            if(blog == null) 
                return NotFound();

            var blogByBloggerFromStore = blog.BlogsByBlogger.FirstOrDefault(c=>c.BlogId==blogId);   
            if(blogByBloggerFromStore == null) 
                return NotFound();

            blogByBloggerFromStore.BlogTitle=blogsByBlogger.BlogTitle;
            blogByBloggerFromStore.BlogDescription=blogsByBlogger.BlogDescription;

            return NoContent();
        }
        [HttpPatch("{blogId}")]
        public ActionResult PartialUpdateBlogsByBlogger(int bloggerId,int blogId,
            JsonPatchDocument<BlogsByBloggerUpdateDto> patchDocument)
        {
            var blog = BlogsDataStore.Current.Blogs.FirstOrDefault(c=>c.BloggerId == bloggerId);
            if(blog == null) 
                return NotFound();

            var blogByBloggerFromStore = blog.BlogsByBlogger.FirstOrDefault(c=>c.BlogId == blogId);
            if(blogByBloggerFromStore == null) 
                return NotFound() ;

            var blogByBloggerToPatch = new BlogsByBloggerUpdateDto()
            {
                BlogTitle=  blogByBloggerFromStore.BlogTitle,
                BlogDescription= blogByBloggerFromStore.BlogDescription,
            };
            patchDocument.ApplyTo(blogByBloggerToPatch, ModelState);

            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            if(!TryValidateModel(blogByBloggerToPatch)) 
                return BadRequest(ModelState);  

            blogByBloggerFromStore.BlogTitle=blogByBloggerToPatch.BlogTitle;
            blogByBloggerFromStore.BlogDescription=blogByBloggerToPatch.BlogDescription;

            return NoContent();
        }
        [HttpDelete]
        public ActionResult DeleteBlogByBlogger(int bloggerId,int blogId)
        {
            var blog =BlogsDataStore.Current.Blogs.FirstOrDefault(c=>c.BloggerId == bloggerId);
            if(blog == null) 
                return NotFound() ;
            var blogByBloggerFromStore = blog.BlogsByBlogger.FirstOrDefault(c=>c.BlogId== blogId);
            if(blogByBloggerFromStore== null)
                return NotFound();
            blog.BlogsByBlogger.Remove(blogByBloggerFromStore);
            return NoContent();
        }
    }
}
