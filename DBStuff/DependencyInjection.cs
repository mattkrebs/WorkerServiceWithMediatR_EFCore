using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace DBStuff
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, string connection)
        {
            services.AddDbContext<MyContext>(options =>
                  options.UseSqlServer(connection));

            services.AddScoped<IMyContext>(provider => provider.GetService<MyContext>());

            return services;
        }
    }
}
