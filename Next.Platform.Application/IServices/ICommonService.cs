using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Next.Platform.Application.IServices
{
   public interface ICommonService
   {
       Task<string> UploadImage(IFormFile imageFile, string folderName);
   }
}
