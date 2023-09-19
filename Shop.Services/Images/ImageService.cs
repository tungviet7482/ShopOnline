using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Shop.Services.Images
{
    public class ImageService: IImageService
    {
        public async Task<bool> UploadFile(IFormFile fromFile)
        {
            if(fromFile != null)
            {
                string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Images", fromFile.FileName);

                List<string> listExtens = new List<string>{ ".jpg", ".png"};

                if (!listExtens.Contains(Path.GetExtension(path)))
                    return false;

                using(var file = new FileStream(path, FileMode.Create))
                {
                    await fromFile.CopyToAsync(file);
                }
                return true;
            }
            return false;
        }

        public async Task<bool> DeleteFile(string fileName)
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Images", fileName);
            //var list = Directory.GetFiles(path);
            if(File.Exists(path))
            {
                File.Delete(path);
                return true;
            }
            return false;
        }

        public async Task<FileStream> GetFile(string fileName)
        {
            string path = Path.Combine("~/Images", fileName);
            if(File.Exists(path))
            {
                return  new FileStream(path, FileMode.Open, FileAccess.Read);
            }
            return null;
        }
    }
}
