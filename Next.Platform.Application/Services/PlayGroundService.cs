using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Next.Platform.Application.Dtos;
using Next.Platform.Application.IServices;
using Next.Platform.Core.Model;
using Next.Platform.Core.StatusEnum;
using Next.Platform.Infrastructure.IBaseRepository;

namespace Next.Platform.Application.Services
{
   public class PlayGroundService : IPlayGroundService
   {
       private readonly IRepository<PlayGround> _playGroundRepository;
       private readonly IRepository<PlayGroundImages> _playGroundImagesRepository;
       private readonly IMapper _mapper;
       private readonly ICommonService _commonService;

       public PlayGroundService(IRepository<PlayGroundImages> playGroundImagesRepository,IRepository<PlayGround> playGroundRepository, IMapper mapper, ICommonService commonService)
        {
            this._playGroundRepository = playGroundRepository;
            this._mapper = mapper;
            this._commonService = commonService;
            this._playGroundImagesRepository = playGroundImagesRepository;
        }
        public Guid CreatePlayGround(PlayGroundDto playGroundDto)
        {
               PlayGround resualt =  _mapper.Map<PlayGround>(playGroundDto);
               resualt.Id =Guid.NewGuid();
               resualt.Rating = 0;
               resualt.PlayGroundStatusId = PlayGroundStatusEnum.Pending;
               resualt.OwnerId = playGroundDto.OwnerId;
               _playGroundRepository.Add(resualt);
               AddImages(playGroundDto.ImageFile,resualt.Id);
               return resualt.Id;
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
                playGroundImage.Path = "DefaultPlayGroundImage.jpg";
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
   }
}
