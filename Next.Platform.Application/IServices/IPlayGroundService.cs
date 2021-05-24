using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Http;
using Next.Platform.Application.Dtos;
using Next.Platform.Application.DtosValidator;
using Next.Platform.Application.ViewModel;
using Next.Platform.Core.Model;

namespace Next.Platform.Application.IServices
{
  public interface IPlayGroundService
  {
      Guid CreatePlayGround(PlayGroundDto playGroundDto);
      PlayGround GetById(Guid playGroundId);
      void Save(PlayGround playGround);
      void AddImages(IFormFile[] imageFile, Guid playGroundId);
     List<PlayGroundApprovalViewModel> GetPlayGroundApprovalViewModel();
     int GetPlayGroundApprovalViewModelCount();
     List<PlayGroundListViewModel> GetPlayGroundlist(Guid playGroundCategoryId);
     PlayGroundViewModel GetPlayGround(Guid playGroundId);
     List<PlayGroundsTypesViewModel> GetTypes();
     List<StatisticReservationsViewModel> PlayGroundStatusStatistics();
     List<PlayGroundViewModel> GetAllPlayPlayGround();
     int GetAllPlayPlayGroundCount();
  }
}
