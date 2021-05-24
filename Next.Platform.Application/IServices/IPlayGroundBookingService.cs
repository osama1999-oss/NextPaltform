using System;
using System.Collections.Generic;
using System.Text;
using Next.Platform.Application.Dtos;
using Next.Platform.Application.ViewModel;
using Next.Platform.Core.Model;

namespace Next.Platform.Application.IServices
{
  public  interface IPlayGroundBookingService
  {
      void CancelReservation(Guid reservationId);
      List<PlayGroundReservationsViewModel> GetReservationRequest(Guid playGroundId);
     List<PlayGroundReservationsViewModel> GetCurrentReservations();
      List<PlayGroundReservationsViewModel> GetReservationsHistory();
      List<int> GetReservedHours(Guid playGroundId, DateTime day);
      List<PlayGroundBooking> GetReservedDate(Guid playGroundId);
      string Reserve(ReserveDto reserveDto);
      List<StatisticsData> StatisticsOfReservations();
      List<StatisticReservationsViewModel> DailyStatisticsOfReservations();
  }
}
