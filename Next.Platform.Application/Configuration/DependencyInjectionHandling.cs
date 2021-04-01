using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Next.Platform.Infrastructure.AppContext;

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


            //Services
        }
    }
}
