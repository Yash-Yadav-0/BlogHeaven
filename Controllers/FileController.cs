using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;

namespace BlogHeaven.Controllers
{
    [Route("api/files")]
    [ApiController]
    public class FileController : ControllerBase
    {
        private readonly FileExtensionContentTypeProvider _fileExtensionContentTypeProvider;

        public FileController(FileExtensionContentTypeProvider fileExtensionContentTypeProvider)
        {
            _fileExtensionContentTypeProvider = fileExtensionContentTypeProvider
                ?? throw new System.ArgumentNullException(nameof(fileExtensionContentTypeProvider));
        }

        [HttpGet("{fileId}")]
        public ActionResult GetFile(string fileId)
        {
            var filePath = "Profile.pdf";
            if(!System.IO.File.Exists(filePath))
                return NotFound();
            if(!_fileExtensionContentTypeProvider.TryGetContentType(filePath, out var contentType))
            {
                contentType = "application/octen-stream";
            }
            var bytes=System.IO.File.ReadAllBytes(filePath);
            return File(bytes, contentType, Path.GetFileName(filePath));
        }
        [HttpPost]
        public async Task<ActionResult> CreateFile(IFormFile file)
        {
            //validate input
            if(file.Length == 0 || file.Length > 20099 || file.ContentType!="Profile/pdf")
            {
                return BadRequest("No file or invalid input");
            }
            var path = Path.Combine(Directory.GetCurrentDirectory(),$"uploaded_file_{Guid.NewGuid()}.pdf");
            using(var stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }
            return Ok("Your file has been uploaded successfully!");
        }
    }
}
