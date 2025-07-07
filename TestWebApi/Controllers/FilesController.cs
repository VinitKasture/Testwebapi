using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.Extensions.FileProviders;

namespace TestWebApi.Controllers
{
    [Route("api/files")]
    //[Route("api/v{version:apiVersion}/files")]
    //  [Authorize]
    [ApiController]
    public class FilesController : Controller
    {
        [HttpPost]
        public async Task<ActionResult> CreateFile(IFormFile file)
        {
            if (file.Length == 0 || file.Length > 2154687) return BadRequest("Invalid file");

            var path = Path.Combine(Directory.GetCurrentDirectory(), $@"New_file{Guid.NewGuid()}.pdf");
            using(var stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }
            return Ok("File uploaded");
        }


    }
}
