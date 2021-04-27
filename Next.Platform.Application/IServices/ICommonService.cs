using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Next.Platform.Application.ViewModel;

namespace Next.Platform.Application.IServices
{
   public interface ICommonService
   {
       List<NeighborhoodViewModel> GetNeighborhoods();
       string GetNeighborhood(Guid LocationId);
       Task<string> UploadImage(IFormFile imageFile, string folderName);
   }
}
