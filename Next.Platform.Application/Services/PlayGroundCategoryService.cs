using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Next.Platform.Application.Dtos;
using Next.Platform.Application.IServices;
using Next.Platform.Application.ViewModel;
using Next.Platform.Core.Model;
using Next.Platform.Infrastructure.IBaseRepository;

namespace Next.Platform.Application.Services
{
   public class PlayGroundCategoryService:IPlayGroundCategoryService
   {
       private readonly IMapper _mapper;
       private readonly IRepository<PlayGroundCategory> _playGroundCategoryRepository;
       private readonly ICommonService _commonService;
       private readonly IPlayGroundService _playGroundService;

        public PlayGroundCategoryService(ICommonService  commonService, IPlayGroundService playGroundService,
            IRepository<PlayGroundCategory> playGroundCategoryRepository, IMapper mapper)
        {
            this._playGroundCategoryRepository = playGroundCategoryRepository;
            this._mapper = mapper;
            this._commonService = commonService;
            this._playGroundService = playGroundService;
        }

        public Guid CreatePlayGroundCategory(PlayGroundCategoryDto playGroundCategoryDto)
        {
            var result = _mapper.Map<PlayGroundCategory>(playGroundCategoryDto);
            result.Id = Guid.NewGuid();
            result.OwnerId = playGroundCategoryDto.OwnerId;
            result.Image =   _commonService.UploadImage(playGroundCategoryDto.ImageFile, "PlayGroundCategory").Result;
            _playGroundCategoryRepository.Add(result);
            return result.Id;
        }
        public List<PlayGroundCategoriesViewModel> GetPlayGroundCategories()
        {
            var result = _playGroundCategoryRepository.Get().ToList();
            var categories = _mapper.Map<List<PlayGroundCategoriesViewModel>>(result);
            foreach (var category in categories)
            {

             category.Count = _playGroundService.GetPlayGroundlist(category.Id).Count;

            }
            return categories;
        }
    }
}
