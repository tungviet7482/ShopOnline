using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shop.Services.Images;
using System.IO;
using System.Threading.Tasks;

namespace Shop.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageController : ControllerBase
    {

        private readonly IImageService _imageService;

        public ImageController(IImageService imageService)
        {
            _imageService = imageService;
        }

        [HttpPost]
        [RequestSizeLimit(1_073_741_824)]
        public async Task<IActionResult> UploadFile(IFormFile formFile)
        {
            var res = await _imageService.UploadFile(formFile);
            if(res)
            return Ok(res);
            return BadRequest();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteFile(string fileName)
        {
            var res = await _imageService.DeleteFile(fileName);
            if (res)
                return Ok(res);
            return BadRequest();
        }

        
        [HttpGet("{imageName}")]
        public IActionResult GetImage(string imageName)
        {
            // Đường dẫn tới thư mục chứa ảnh trong wwwroot
            var imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", imageName);

            // MIME type cho tệp ảnh (ví dụ: "image/jpeg")
            var contentType = "image/jpeg";

            // Trả về tệp ảnh
            return PhysicalFile(imagePath, contentType);
        }

        [HttpGet("file/{fileName}")]
        public IActionResult GetFile(string fileName)
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(),"wwwroot","Images", fileName);
            if (!System.IO.File.Exists(path))
            {
                return NotFound();
            }

            var videoStream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read);
            return new FileStreamResult(videoStream, "video/mp4");
        }

    }
}
