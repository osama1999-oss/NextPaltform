using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Next.Platform.Application.IServices;
using Next.Platform.Application.ViewModel;
using Next.Platform.Core.Model;
using Next.Platform.Infrastructure.IBaseRepository;

namespace Next.Platform.Application.Services
{
  public  class CommonService : ICommonService
    {
        private readonly IWebHostEnvironment _hostEnvironment;
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly IRepository<Neighborhood> _neighborhoodRepository;
        private readonly IMapper _mapper;


        public CommonService(IWebHostEnvironment hostEnvironment, IHostingEnvironment hostingEnvironment, IRepository<Neighborhood> neighborhoodRepository, IMapper mapper)
        {
            this._hostEnvironment = hostEnvironment;
            this._neighborhoodRepository = neighborhoodRepository;
            this._mapper = mapper;
            this._hostingEnvironment = hostingEnvironment;

        }

        public List<NeighborhoodViewModel> GetNeighborhoods()
        {
            var result = _neighborhoodRepository.Get().ToList();
            var neighborhoods = _mapper.Map<List<NeighborhoodViewModel>>(result);
            return neighborhoods;
        }

        public string GetNeighborhood(Guid LocationId)
        {
          var result=  _neighborhoodRepository.FindBy(n => n.Id == LocationId).Select(n => n.Name).FirstOrDefault();
          return result;
        }

        public async Task<string> UploadImage(IFormFile imageFile, string folderName)
        {
            string wwwRootPath = _hostEnvironment.WebRootPath;
            string fileName = Path.GetFileNameWithoutExtension(imageFile.FileName);
            string extension = Path.GetExtension(imageFile.FileName);
            string imageName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
            string value =   "Images/" + folderName + "/" + imageName;
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

            return value;
        }
    }
}
