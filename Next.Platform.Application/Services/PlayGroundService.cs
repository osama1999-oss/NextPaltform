using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Next.Platform.Application.Dtos;
using Next.Platform.Application.IServices;
using Next.Platform.Application.ViewModel;
using Next.Platform.Core.Model;
using Next.Platform.Core.StatusEnum;
using Next.Platform.Infrastructure.AppContext;
using Next.Platform.Infrastructure.IBaseRepository;

namespace Next.Platform.Application.Services
{
   public class PlayGroundService : IPlayGroundService
   {
       private readonly IRepository<PlayGround> _playGroundRepository;
       private readonly IRepository<PlayGroundImages> _playGroundImagesRepository;
       private readonly IMapper _mapper;
       private readonly ICommonService _commonService;
       private readonly NextPlatformDbContext _context;
       private readonly IPlayGroundBookingService _bookingService;
       private readonly IRepository<PlayGroundType> _playGroundTypeRepository;

       public PlayGroundService(NextPlatformDbContext context,IRepository<PlayGroundImages> playGroundImagesRepository,
           IRepository<PlayGround> playGroundRepository, IMapper mapper, ICommonService commonService, IPlayGroundBookingService bookingService,
           IRepository<PlayGroundType> playGroundTypeRepository)
        {
            this._playGroundRepository = playGroundRepository;
            this._mapper = mapper;
            this._commonService = commonService;
            this._playGroundImagesRepository = playGroundImagesRepository;
            this._context = context;
            this._playGroundTypeRepository = playGroundTypeRepository;
            this._bookingService = bookingService;
        }

        public Guid CreatePlayGround(PlayGroundDto playGroundDto)
        {
               PlayGround result =  _mapper.Map<PlayGround>(playGroundDto);
               result.Id =Guid.NewGuid();
               result.Location = playGroundDto.Location;
               result.Rating = 0;
               result.PlayGroundStatusId = PlayGroundStatusEnum.Pending;
               result.PlayGroundCategoryId = playGroundDto.PlayGroundCategoryId;
               _playGroundRepository.Add(result);
               AddImages(playGroundDto.ImageFile, result.Id);
               return result.Id;
        }
        public PlayGround GetById(Guid playGroundId)
        {
            return _playGroundRepository.FindBy(p => p.Id == playGroundId).FirstOrDefault();
        }
        public void Save(PlayGround playGround)
        {
            _playGroundRepository.Edit(playGround);
        }
        public void AddImages(IFormFile[] imageFile ,Guid playGroundId)
        {

            PlayGroundImages playGroundImage = new PlayGroundImages();
            playGroundImage.PlayGroundId = playGroundId;
            if (imageFile == null)
            {
                playGroundImage.Id = Guid.NewGuid();
                playGroundImage.Path = "Images/" + "DefaultPlayGroundImage.jpg";
                _playGroundImagesRepository.Add(playGroundImage);
            }
            else
            {
                foreach (var image in imageFile)
                {
                    playGroundImage.Id = Guid.NewGuid();
                    Task<string> imageName = _commonService.UploadImage(image, "PlayGrounds");
                    playGroundImage.Path = imageName.Result;
                    _playGroundImagesRepository.Add(playGroundImage);
                }
            }
        }
        public List<PlayGroundApprovalViewModel> GetPlayGroundApprovalViewModel()
        {

            var result = from o in _context.Owners
                         join pc in _context.PlayGroundCategories on o.Id equals pc.OwnerId
                         join ps in _context.PlayGrounds on pc.Id equals ps.PlayGroundCategoryId
                         where ps.PlayGroundStatusId == PlayGroundStatusEnum.Pending
                         select new PlayGroundApprovalViewModel()
                         {
                             PlayGroundCategoryId = pc.Id,
                             OwnerName = o.Name,
                             PlayGroundId = ps.Id,
                             PlayGroundName = ps.Name,
                             PriceEvening = ps.PriceEvening,
                             PriceMorning = ps.PriceMorning,
                             NeighborhoodId = pc.NeighborhoodId,
                             Email = o.Email,
                             PlayGroundCategoryName = pc.Name
                         };

            List<PlayGroundApprovalViewModel> approvalViewModels = new List<PlayGroundApprovalViewModel>();
            foreach (var res in result)
            {
                res.Images = _playGroundImagesRepository.FindBy(p => p.PlayGroundId == res.PlayGroundId).Select(p => p.Path).ToList();
                res.Location = _commonService.GetNeighborhood(res.NeighborhoodId);
                approvalViewModels.Add(res);
            }

            var x = approvalViewModels.GroupBy(p => p.PlayGroundCategoryId);

            return approvalViewModels;
        }

        public int GetPlayGroundApprovalViewModelCount()
        {
            return GetPlayGroundApprovalViewModel().Count;
        }

        public List<PlayGroundListViewModel> GetPlayGroundlist(Guid playGroundCategoryId)
        {
            var result = _playGroundRepository.FindBy(p => p.PlayGroundCategoryId == playGroundCategoryId && p.PlayGroundStatusId == PlayGroundStatusEnum.Approved).ToList();
            var playGrounds = _mapper.Map<List<PlayGroundListViewModel>>(result);
            return playGrounds;
        }

        public PlayGroundViewModel GetPlayGround(Guid playGroundId)
        {
            var result = _playGroundRepository.FindBy(p => p.Id == playGroundId && p.PlayGroundStatusId ==PlayGroundStatusEnum.Approved ).FirstOrDefault();
           
            var playGround = _mapper.Map<PlayGroundViewModel>(result);
            DateTime date1 = new DateTime(2021, 05, 23);
            playGround.ReservedHours = _bookingService.GetReservedHours(playGroundId,date1);
            return playGround;
        }

        public List<PlayGroundsTypesViewModel> GetTypes()
        {
            var result = _playGroundTypeRepository.Get().ToList();
            var types = _mapper.Map<List<PlayGroundsTypesViewModel>>(result);
            return types;
        }

        public List<StatisticReservationsViewModel> PlayGroundStatusStatistics()
        {
            var playGrounds = _playGroundRepository.Get().ToList();
            var group = playGrounds.GroupBy(x => x.PlayGroundStatusId).ToList();
            List<StatisticReservationsViewModel> dataList = new List<StatisticReservationsViewModel>();
            foreach (var gr in group)
            {
                StatisticReservationsViewModel data = new StatisticReservationsViewModel();
                data.Name = gr.Key.ToString();
                data.Value = gr.Count();
                dataList.Add(data);
            }

            return dataList;
        }

        public List<PlayGroundViewModel> GetAllPlayPlayGround()
        {
            var result = _playGroundRepository.Get().Where(c=> c.PlayGroundStatusId == PlayGroundStatusEnum.Approved).ToList();
            var playGrounds = _mapper.Map<List<PlayGroundViewModel>>(result);

            foreach (var pl in playGrounds)
            {
                pl.Image= _playGroundImagesRepository.FindBy(p => p.PlayGroundId == pl.Id).Select(p => p.Path).ToList();
               
            }
            return playGrounds;
        }

        public int GetAllPlayPlayGroundCount()
        {
            return GetAllPlayPlayGround().Count;
        }


        //public List< PlayGroundCategoriesViewModel> GetPlayGroundCategories()
        //{
        //    var result = from o in _context.Owners
        //        join pc in _context.PlayGroundCategories on o.Id equals pc.OwnerId
        //        join ps in _context.PlayGrounds on pc.Id equals ps.PlayGroundCategoryId
        //        where ps.PlayGroundStatusId == PlayGroundStatusEnum.Pending
        //        select new PlayGroundCategoriesViewModel()
        //        {
        //            PlayGroundCategoryId = pc.Id,
        //            OwnerName = o.Name,
        //            PlayGroundId = ps.Id,
        //            PlayGroundName = ps.Name,
        //            PriceEvening = ps.PriceEvening,
        //            PriceMorning = ps.PriceMorning,
        //            PlayGroundLocation = ps.Location,
        //            Email = o.Email
        //        };

        //    List<PlayGroundCategoriesViewModel> categoriesViewModels = new List<PlayGroundCategoriesViewModel>();
        //    foreach (var res in result)
        //    {
        //        res.Images = _playGroundImagesRepository.FindBy(p => p.PlayGroundId == res.PlayGroundId).Select(p => p.Path).ToList();
        //        categoriesViewModels.Add(res);
        //    }

        //    var categories = categoriesViewModels.GroupBy(p => p.PlayGroundCategoryId);

        //    return categoriesViewModels;
        //}
   }
}
