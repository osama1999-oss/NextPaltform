using System;
using System.Collections.Generic;
using System.Text;
using Next.Platform.Application.Dtos;
using Next.Platform.Application.SearchCriteria;
using Next.Platform.Application.ViewModel;
using Next.Platform.Core.Model;

namespace Next.Platform.Application.IServices
{
  public interface IPlayGroundCategoryService
  {
      PlayGroundCategory GetCategoryById(Guid playGroundId);
     string CreatePlayGroundCategory(PlayGroundCategoryDto playGroundCategoryDto);
     List<PlayGroundCategoriesViewModel> GetPlayGroundCategories();
     List<PlayGroundCategoriesViewModel> Filter(PlayGroundCategorySearchCriteria categorySearchCriteria);
     List<PlayGroundCategoriesViewModel> Order(string orderBy);
     string GetLocation(Guid playGroundCategoryId);
    }
}
