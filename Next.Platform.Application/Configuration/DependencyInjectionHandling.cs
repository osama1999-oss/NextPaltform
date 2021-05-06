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
                options.UseSqlServer("Data Source=. ;Initial Catalog=NextPlatformDbv10;Persist Security Info=True;User ID=sa;Password=osamahamdy;MultipleActiveResultSets=True;Connect Timeout=30;");
            });

            // Repository
            services.AddTransient<IRepository<User>, Repository<User>>();
            services.AddTransient<IRepository<Owner>, Repository<Owner>>();
            services.AddTransient<IRepository<Admin>, Repository<Admin>>();
            services.AddTransient<IRepository<PlayGround>, Repository<PlayGround>>();
            services.AddTransient<IRepository<PlayGroundImages>, Repository<PlayGroundImages>>();
            services.AddTransient<IRepository<PlayGroundCategory>, Repository<PlayGroundCategory>>();
            services.AddTransient<IRepository<PlayGroundType>, Repository<PlayGroundType>>();
            services.AddTransient<IRepository<Neighborhood>, Repository<Neighborhood>>();
            services.AddTransient<IRepository<PlayGroundBooking>, Repository<PlayGroundBooking>>();
            services.AddTransient<IRepository<PreferredPlayGround>, Repository<PreferredPlayGround>>();

            //Services
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IAuthenticateService, AuthenticationService>();
            services.AddTransient<IOwnerService, OwnerService>();
            services.AddTransient<IAdminService, AdminService>();
            services.AddTransient<IVerificationService, VerificationService>();
            services.AddTransient<IPlayGroundService, PlayGroundService>();
            services.AddTransient<ICommonService, CommonService>();
            services.AddTransient<IPlayGroundCategoryService, PlayGroundCategoryService>();
            services.AddTransient<IPlayGroundBookingService, PlayGroundBookingService>();
            services.AddHttpContextAccessor();
            

        }
    }
}
