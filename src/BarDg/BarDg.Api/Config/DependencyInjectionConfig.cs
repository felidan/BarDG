using BarDg.Core.Application.Services;
using BarDg.Core.Domain.Repositories;
using BarDg.Core.Domain.Services;
using BarDg.Infra.Repository.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace BarDg.Api.Config
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection DependencyInjectionConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            if (services == null)
                throw new ArgumentNullException(nameof(services));

            services.AddSingleton(configuration);

            #region Services

            services.AddScoped<IComandaService, ComandaService>();
            services.AddScoped<ILoginService, LoginService>();
            services.AddScoped<ILogService, LogService>();
            services.AddScoped<IPromocaoService, PromocaoService>();

            #endregion

            #region Repository

            services.AddScoped<IComandaRepository, ComandaRepository>();
            services.AddScoped<ILoginRepository, LoginRepository>();
            services.AddScoped<ILogRepository, LogRepository>();
            
            #endregion

            return services;
        }
    }
}
