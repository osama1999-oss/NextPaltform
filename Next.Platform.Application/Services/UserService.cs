using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using Next.Platform.Application.Dtos;
using Next.Platform.Application.IServices;
using Next.Platform.Core.Model;
using Next.Platform.Infrastructure.IBaseRepository;

namespace Next.Platform.Application.Services
{
   public class UserService : IUserService
   {
       private readonly IRepository<User> _userRepository;
       private readonly IMapper _mapper;
        public UserService(IRepository<User> useRepository, IMapper mapper)
        {
            this._userRepository = useRepository;
            this._mapper = mapper;
        }
        public UserAuthenticationDto Login(UserAuthenticationDto userDto)
        {
             var result= _userRepository.FindBy(u => u.PhoneNumber == userDto.PhoneNumber && u.Password == userDto.Password)
                    .FirstOrDefault();
             var userDtoResult = _mapper.Map<UserAuthenticationDto>(result);
             return userDtoResult;
        }
    }
}
