using System;
using Meridia.Application.Interfaces.Repositories;
using Meridia.Application.Interfaces;
using Meridia.Infrastructure.Repositories;
using Meridia.Persistence.Data;
using Meridia.Persistence.Repositories;
using Meridia.Persistence.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Meridia.Persistence.DependencyResolver
{
    public static class DependencyResolverService
    {
        public static void Register(IServiceCollection services, IConfiguration Configuration)
        {
            services.AddDbContext<MeridiaDbContext>(options =>
                options.UseSqlServer(
                    "name=ConnectionStrings:MeridiaDatabase",
                        x => x.MigrationsAssembly("Meridia.Persistence")));

            services.AddScoped(typeof(IBaseRepositoryAsync<>), typeof(BaseRepositoryAsync<>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IUserService, UserService>();

        }

        public static void MigrateDatabase(IServiceProvider serviceProvider)
        {
            var dbContextOptions = serviceProvider.GetRequiredService<DbContextOptions<MeridiaDbContext>>();
            using (var dbContext = new MeridiaDbContext(dbContextOptions))
            {
                dbContext.Database.Migrate();
            }
        }
    }
}