using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Services.Images
{
    public interface IImageService
    {
        Task<bool> DeleteFile(string fileName);
        Task<FileStream> GetFile(string fileName);
        Task<bool> UploadFile(IFormFile fromFile);
    }
}
