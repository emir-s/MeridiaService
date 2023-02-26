using System;
using Meridia.Application.Core.Repositories;
using Meridia.Application.Core.Services;
using Meridia.Infrastructure.Data;
using Meridia.Infrastructure.Repositories;
using Meridia.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Meridia.Infrastructure.DependencyResolver
{
    public static class DependencyResolverService
    {
        public static void Register(IServiceCollection services, IConfiguration Configuration)
        {
            services.AddDbContext<MeridiaDbContext>(options =>
                options.UseSqlServer(
                    "name=ConnectionStrings:MeridiaDatabase",
                    x => x.MigrationsAssembly("Meridia.DbMigrations")));

            services.AddScoped(typeof(IBaseRepositoryAsync<>), typeof(BaseRepositoryAsync<>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ILoggerService, LoggerService>();
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