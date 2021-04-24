using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Next.Platform.Application.IServices;

namespace Next.Platform.Application.Services
{
  public  class CommonService : ICommonService
    {
        private readonly IWebHostEnvironment _hostEnvironment;

        public CommonService(IWebHostEnvironment hostEnvironment)
        {
            this._hostEnvironment = hostEnvironment;

        }
        public async Task<string> UploadImage(IFormFile imageFile, string folderName)
        {
            string wwwRootPath = _hostEnvironment.WebRootPath;
            string fileName = Path.GetFileNameWithoutExtension(imageFile.FileName);
            string extension = Path.GetExtension(imageFile.FileName);
            string imageName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
            string path = Path.Combine(wwwRootPath + "\\Images\\" + folderName + "\\", imageName);
            try
            {
                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    await imageFile.CopyToAsync(fileStream);
                }
            }
            catch (Exception e)
            {
                throw;
            }

            return imageName;
        }
    }
}
