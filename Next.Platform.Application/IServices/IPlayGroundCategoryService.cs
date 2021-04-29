using System;
using System.Collections.Generic;
using System.Text;
using Next.Platform.Application.Dtos;
using Next.Platform.Application.SearchCriteria;
using Next.Platform.Application.ViewModel;

namespace Next.Platform.Application.IServices
{
  public interface IPlayGroundCategoryService
    {
     string CreatePlayGroundCategory(PlayGroundCategoryDto playGroundCategoryDto);
     List<PlayGroundCategoriesViewModel> GetPlayGroundCategories();
     List<PlayGroundCategoriesViewModel> Filter(PlayGroundCategorySearchCriteria categorySearchCriteria);
     List<PlayGroundCategoriesViewModel> Order(string orderBy);
     string GetLocation(Guid playGroundCategoryId);
    }
}
