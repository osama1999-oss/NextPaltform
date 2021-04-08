using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Next.Platform.Application.Dtos;
using Next.Platform.Application.IServices;
using Next.Platform.Application.Services;
using Next.Platform.Core.Model;
using Next.Platform.Infrastructure.AppContext;
using Next.Platform.Infrastructure.IBaseRepository;
using Xunit;

namespace Next.Platform.Test
{
   public class UserServiceTest
    {
        //private readonly IRepository<User> _userRepository;
        //private readonly IAuthenticateService _AuthenticateService;
        //private readonly IMapper _mapper;
        //public UserServiceTest(IRepository<User> useRepository, IMapper mapper, IAuthenticateService AuthenticateService)
        //{
        //    this._userRepository = useRepository;
        //    this._mapper = mapper;
        //    this._AuthenticateService = AuthenticateService;
        //}
        //private IUserService GetInMemoryPersonRepository()
        //{
        //    DbContextOptions<NextPlatformDbContext> options;
        //    var builder = new DbContextOptionsBuilder<NextPlatformDbContext>();
        //    builder.UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString());
        //    options = builder.Options;
        //    NextPlatformDbContext userDataContext = new NextPlatformDbContext(options);
        //    userDataContext.Database.EnsureCreated();
        //    var user = new[]
        //    {
        //        new User() {Name = "osama", Password = "123", PhoneNumber = "1234"}
        //    };
        //    userDataContext.Users.AddRange(user);
        //    userDataContext.SaveChanges();
        //    return new UserService(_userRepository, _mapper, _AuthenticateService);
        //}

        //[Fact]
        //public void Login_WhenHaveNoAccount()
        //{
        //    IUserService userService = GetInMemoryPersonRepository();
        //    UserAuthenticationDto user = new UserAuthenticationDto()
        //    {
        //        PhoneNumber = "1234",
        //        Password ="123"
        //    };
        //    var result= userService.Login(user);
        //    Assert.Null(result);
        //}

    }
}
