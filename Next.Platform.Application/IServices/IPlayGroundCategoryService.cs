using System;
using System.Collections.Generic;
using System.Text;
using Next.Platform.Application.Dtos;
using Next.Platform.Application.ViewModel;

namespace Next.Platform.Application.IServices
{
  public interface IPlayGroundCategoryService
    {
     Guid CreatePlayGroundCategory(PlayGroundCategoryDto playGroundCategoryDto);
     List<PlayGroundCategoriesViewModel> GetPlayGroundCategories();

    }
}
