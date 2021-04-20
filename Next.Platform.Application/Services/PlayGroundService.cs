using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Next.Platform.Application.Dtos;
using Next.Platform.Application.IServices;
using Next.Platform.Core.Model;
using Next.Platform.Core.StatusEnum;
using Next.Platform.Infrastructure.IBaseRepository;

namespace Next.Platform.Application.Services
{
   public class PlayGroundService : IPlayGroundService
   {
       private readonly IRepository<PlayGround> _playGroundService;
       private readonly IMapper _mapper;

        public PlayGroundService(IRepository<PlayGround> playGroundService, IMapper mapper)
        {
            this._playGroundService = playGroundService;
            this._mapper = mapper;
        }
        public Guid CreatePlayGround(PlayGroundDto playGroundDto)
        {
               var resualt =  _mapper.Map<PlayGround>(playGroundDto);
               resualt.Id =Guid.NewGuid();
               resualt.Rating = 0;
               resualt.PlayGroundStatusId = PlayGroundStatusEnum.Pending;
               resualt.OwnerId = playGroundDto.OwnerId;
                _playGroundService.Add(resualt);
                return resualt.Id;
        }
    }
}
