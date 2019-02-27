using System;

using Microsoft.Extensions.DependencyInjection;

using AutoMapper;

namespace HJR.FinanceControl.WebApp.Helpers.AutoMapper.Extensions
{
    public static class AutoMapperSetup
    {
        public static void AddAutoMapperSetup(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddAutoMapper();

            AutoMapperConfig.RegisterMappings();
        }
    }
}