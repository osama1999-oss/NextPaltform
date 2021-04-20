using System;
using System.Collections.Generic;
using System.Text;
using Next.Platform.Application.Dtos;
using Next.Platform.Application.DtosValidator;

namespace Next.Platform.Application.IServices
{
  public interface IPlayGroundService
  {
      Guid CreatePlayGround(PlayGroundDto playGroundDto);
  }
}
