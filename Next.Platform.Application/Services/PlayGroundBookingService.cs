using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using AutoMapper;
using Next.Platform.Application.Dtos;
using Next.Platform.Application.IServices;
using Next.Platform.Application.ViewModel;
using Next.Platform.Core.Model;
using Next.Platform.Core.StatusEnum;
using Next.Platform.Infrastructure.AppContext;
using Next.Platform.Infrastructure.IBaseRepository;

namespace Next.Platform.Application.Services
{
  public  class PlayGroundBookingService : IPlayGroundBookingService
  {
      private readonly IRepository<PlayGroundBooking> _playGroundBookingRepository;
      private readonly IMapper _mapper;
      private readonly NextPlatformDbContext _context;

        public PlayGroundBookingService(NextPlatformDbContext context, IRepository<PlayGroundBooking> playGroundBookingRepository, IMapper mapper)
        {
            this._mapper = mapper;
            this._context = context;
            this._playGroundBookingRepository = playGroundBookingRepository;
        }
        private bool IfReservationDateIsAvailable(PlayGroundBooking playGroundBooking)
        { 
            var result = _playGroundBookingRepository.FindBy(p => p.From == playGroundBooking.From && p.DateOnly == playGroundBooking.DateOnly &&
                                           p.To == playGroundBooking.To && p .PlayGroundId == playGroundBooking.PlayGroundId && p.PlayGroundBookingStatusId != PlayGroundBookingStatusEnum.Canceled);
            if (result.Count == 0) return true;
            return false;

        }

        public void CancelReservation(Guid reservationId)
        {
            var result = _playGroundBookingRepository.FindBy(p => p.Id == reservationId).FirstOrDefault();
            result.PlayGroundBookingStatusId = PlayGroundBookingStatusEnum.Canceled;
            _playGroundBookingRepository.Edit(result);
        }

        public List<PlayGroundReservationsViewModel> GetReservationRequest(Guid playGroundId)
        {
            var result = GetCurrentReservations().Where(p => p.PlayGroundId == playGroundId &&
                                                             p.Status == PlayGroundBookingStatusEnum.Pending.ToString()).ToList();
            return result;
        }

        public List<PlayGroundReservationsViewModel> GetCurrentReservations()
        {
            var yesterday = DateTime.Today.AddDays(-1).Date;
            var toDay = DateTime.Today.AddDays(0).Date;
            var currentTime = DateTime.Now.ToString("HH");
            var passedTime = Int16.Parse(currentTime);
            
            var results = from b in _context.PlayGroundBookings
                                 join pl in _context.PlayGrounds on b.PlayGroundId equals pl.Id
                                 join u in _context.Users on b.UserId equals u.Id
                                 where b.DateOnly > toDay || (b.DateOnly == toDay && b.From > passedTime ) && b.PlayGroundBookingStatusId != PlayGroundBookingStatusEnum.Canceled
                                  select new PlayGroundReservationsViewModel()
                                  {
                                      Id = b.Id,
                                      PlayGroundId = b.PlayGroundId,    
                                      UserId = b.UserId,
                                      PlayGroundName = pl.Name,
                                      UserName = u.Name,
                                      From = b.From,
                                      Date = b.DateOnly.ToString(),
                                      To = b.To,
                                      Status = b.PlayGroundBookingStatusId.ToString()
                                  };

            return results.ToList();
        }
        public List<PlayGroundReservationsViewModel> GetReservationsHistory()
        {
            var toDay = DateTime.Now.Date;
            var currentTime = DateTime.Now.ToString("HH");
            var passedTime = Int16.Parse(currentTime);

            var results = from b in _context.PlayGroundBookings
                join pl in _context.PlayGrounds on b.PlayGroundId equals pl.Id
                join u in _context.Users on b.UserId equals u.Id
                where b.DateOnly <= toDay && b.From <= passedTime  && b.PlayGroundBookingStatusId != PlayGroundBookingStatusEnum.Canceled
                select new PlayGroundReservationsViewModel()
                {
                    Id = b.Id,
                    PlayGroundId = b.PlayGroundId,
                    UserId = b.UserId,
                    PlayGroundName = pl.Name,
                    UserName = u.Name,
                    From = b.From,
                    Date = b.DateOnly.ToString(),
                    To = b.To,
                    Status = b.PlayGroundBookingStatusId.ToString()
                };

            return results.ToList();
        }

      

        public List<int> GetReservedHours(Guid playGroundId, DateTime day)
        {

            day = day.Date;
            var result = _playGroundBookingRepository.FindBy(p => p.PlayGroundId == playGroundId &&
                                    p.DateOnly == day && p.PlayGroundBookingStatusId != PlayGroundBookingStatusEnum.Canceled)
                                    .Select(p => p.From).ToList();
            return result;
        }
        public List<PlayGroundBooking> GetReservedDate(Guid playGroundId)
        {
            var result = _playGroundBookingRepository.FindBy(p => p.PlayGroundId == playGroundId).ToList();
            return result;
        }
        public string Reserve(ReserveDto reserveDto)
        {

            PlayGroundBooking result = new PlayGroundBooking();
                result.Id = Guid.NewGuid();
                result.PlayGroundBookingStatusId = PlayGroundBookingStatusEnum.Pending;
                result.DateOnly = reserveDto.From.Date;
                result.From = Int16.Parse(reserveDto.From.ToString("HH"));
                result.To = Int16.Parse(reserveDto.To.ToString("HH"));
                result.PlayGroundId = reserveDto.PlayGroundId;
                result.UserId = reserveDto.UserId;
                if (IfReservationDateIsAvailable(result))
                {
                    _playGroundBookingRepository.Add(result);
                    return result.Id.ToString();
            }
           
            return "This Hour Cannot be reserved ";
        }
      
        public List<StatisticsData> StatisticsOfReservations()
        {
            List<StatisticsData> datalList = new List<StatisticsData>();
           var result = _playGroundBookingRepository.Get()
               .Where(x => x.PlayGroundBookingStatusId == PlayGroundBookingStatusEnum.Approved);
            var groups = result.GroupBy(x => x.PlayGroundId).ToList();
            foreach (var group in groups)
            {
              StatisticsData data = new StatisticsData();
              data.Id  = group.Key;
               data.Value = group.Count();
               datalList.Add(data);
            }

          var results=   datalList.OrderByDescending(x => x.Value).ToList();
          return results;
        }
        
        public List<StatisticReservationsViewModel> DailyStatisticsOfReservations()
        {
            var results = _playGroundBookingRepository.Get()
                .Where(x => x.PlayGroundBookingStatusId == PlayGroundBookingStatusEnum.Approved);
            List<StatisticReservationsViewModel> days = new List<StatisticReservationsViewModel>();
            foreach (var result in results)
            {
                StatisticReservationsViewModel data = new StatisticReservationsViewModel();
              var date = Convert.ToDateTime(result.DateOnly.ToString());
              DateTime dateValue = new DateTime(date.Year, date.Month, date.Day);
            data.Name=  dateValue.ToString("dddd");
            data.Value = result.From;
                days.Add(data);
            }

            var statistics = days.GroupBy(x => x.Name).ToList();
            List<StatisticReservationsViewModel> dataList = new List<StatisticReservationsViewModel>();

            foreach (var st in statistics)
            {
                StatisticReservationsViewModel data = new StatisticReservationsViewModel();

                data.Name = st.Key;
                data.Value = st.Count();
                dataList.Add(data);
            }

            return dataList;
        }
  }
}
