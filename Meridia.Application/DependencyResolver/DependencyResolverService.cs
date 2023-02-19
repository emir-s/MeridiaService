using System;
using Meridia.Application.Interfaces;
using Meridia.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Meridia.Application.DependencyResolver
{
	public static class DependencyResolverService
	{
        public static void Register(IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
        }
    }
}

