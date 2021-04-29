using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using AutoMapper;
using Next.Platform.Application.Dtos;
using Next.Platform.Application.IServices;
using Next.Platform.Core.Model;
using Next.Platform.Core.StatusEnum;
using Next.Platform.Infrastructure.IBaseRepository;

namespace Next.Platform.Application.Services
{
  public  class PlayGroundBookingService : IPlayGroundBookingService
  {
      private readonly IRepository<PlayGroundBooking> _playGroundBookingRepository;
      private readonly IMapper _mapper;
        public PlayGroundBookingService(IRepository<PlayGroundBooking> playGroundBookingRepository, IMapper mapper)
        {
            this._mapper = mapper;
            this._playGroundBookingRepository = playGroundBookingRepository;
        }
        private bool IfReservationDateIsAvailable(PlayGroundBooking playGroundBooking)
        { 
            var result = _playGroundBookingRepository.FindBy(p => p.From == playGroundBooking.From &&
                                           p.To == playGroundBooking.To && p .PlayGroundId == playGroundBooking.PlayGroundId && p.PlayGroundBookingStatusId != PlayGroundBookingStatusEnum.Canceled);
            if (result.Count == 0) return true;
            return false;

        }

        public List<PlayGroundBooking> GetReservedDate(Guid playGroundId)
        {
            var result = _playGroundBookingRepository.FindBy(p => p.PlayGroundId == playGroundId).ToList();
            return result;
        }

        public string Reserve(ReserveDto reserveDto)
        {
            
            var result = _mapper.Map<PlayGroundBooking>(reserveDto);
            if (IfReservationDateIsAvailable(result))
            {
                result.Id = Guid.NewGuid();
                result.PlayGroundBookingStatusId = PlayGroundBookingStatusEnum.Pending;
                _playGroundBookingRepository.Add(result);
                return result.Id.ToString();
            }
             
            return "This Hour Cannot be reserved ";
        }

    }
}
