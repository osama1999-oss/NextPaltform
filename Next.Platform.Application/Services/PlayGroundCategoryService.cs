using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Next.Platform.Application.Dtos;
using Next.Platform.Application.IServices;
using Next.Platform.Application.SearchCriteria;
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
       private readonly IOwnerService _ownerService;

        public PlayGroundCategoryService(ICommonService  commonService, IPlayGroundService playGroundService,
            IRepository<PlayGroundCategory> playGroundCategoryRepository, 
            IMapper mapper, IOwnerService ownerService)
        {
            this._playGroundCategoryRepository = playGroundCategoryRepository;
            this._mapper = mapper;
            this._commonService = commonService;
            this._playGroundService = playGroundService;
            this._ownerService = ownerService;
        }

        public PlayGroundCategory GetCategoryById(Guid playGroundId)
        {
            var result = _playGroundCategoryRepository.FindBy(p => p.Id == playGroundId).FirstOrDefault();
            return result;
        }

        public string CreatePlayGroundCategory(PlayGroundCategoryDto playGroundCategoryDto)
        {
            if (_ownerService.IfBlocked(playGroundCategoryDto.OwnerId))
                return "This Owner Is Blocked ..  Cant Add Category";
            var result = _mapper.Map<PlayGroundCategory>(playGroundCategoryDto);
            result.Id = Guid.NewGuid();
            result.OwnerId = playGroundCategoryDto.OwnerId;
            result.Image =   _commonService.UploadImage(playGroundCategoryDto.ImageFile, "PlayGroundCategory").Result;
            _playGroundCategoryRepository.Add(result);
            return result.Id.ToString();
        }
        public List<PlayGroundCategoriesViewModel> GetPlayGroundCategories()
        {
            var result = _playGroundCategoryRepository.Get().ToList();
            var categories = _mapper.Map<List<PlayGroundCategoriesViewModel>>(result);
            foreach (var category in categories)
            {
                category.Location = _commonService.GetNeighborhood(category.NeighborhoodId);
             category.Count = _playGroundService.GetPlayGroundlist(category.Id).Count;

            }
            return categories;
        }

        public List<PlayGroundCategoriesViewModel> Filter(PlayGroundCategorySearchCriteria categorySearchCriteria)
        {
            if (categorySearchCriteria.NeighborhoodId == Guid.Empty || categorySearchCriteria.MaxPrice ==
                0 || categorySearchCriteria.MaxPrice == 0)
            {
                return GetPlayGroundCategories();
            }
            var result = GetPlayGroundCategories()
                .Where(p => p.NeighborhoodId == categorySearchCriteria.NeighborhoodId &&
                            p.Price >= categorySearchCriteria.MinPrice && p.Price <= categorySearchCriteria.MaxPrice);
            return result.ToList();
        }

        public List<PlayGroundCategoriesViewModel> Order(string orderBy)
        {
            //switch (orderBy)
            //{
            //    case "default":
            //    {
            //        GetPlayGroundCategories().Sort(p => p.Price);
            //        break;
            //    }
            //}
            return null;
        }

        public string GetLocation(Guid playGroundCategoryId)
        {
            var result = _playGroundCategoryRepository.FindBy(p => p.Id == playGroundCategoryId)
                .Select(p => p.NeighborhoodId).FirstOrDefault();
            var location = _commonService.GetNeighborhood(result);
            return location;
        }
   }
}
