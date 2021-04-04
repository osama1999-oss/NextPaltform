using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Next.Platform.Application.IServices;
using Next.Platform.Application.Services;
using Next.Platform.Core.Model;
using Next.Platform.Infrastructure.AppContext;
using Next.Platform.Infrastructure.BaseRepository;
using Next.Platform.Infrastructure.IBaseRepository;

namespace Next.Platform.Application.Configuration
{ 
   public static class DependencyInjectionHandling
    {
        public static void Handle(IServiceCollection services)
        {
            services.AddDbContext<NextPlatformDbContext>(options =>
            {
                options.UseSqlServer("Data Source=. ;Initial Catalog=NextPlatformDb;Persist Security Info=True;User ID=sa;Password=osamahamdy;MultipleActiveResultSets=True;Connect Timeout=30;");
            });

            // Repository
            services.AddTransient<IRepository<User>, Repository<User>>();

            //Services
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IAuthenticateService, AuthenticationService>();
            services.AddHttpContextAccessor();

        }
    }
}
