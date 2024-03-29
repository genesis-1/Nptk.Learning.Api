﻿using Nptk.Learning.Contracts;
using Nptk.Learning.LoggerSerice;

namespace Nptk.Learning.Api.Extensions
{
    public static class ServiceExtensions
    {

        public static void ConfigureCors(this IServiceCollection services)
            => services.AddCors(
                options =>
                {
                    options.AddPolicy("CorsPolicy",
                        builder => builder.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader());
                }
                );

        public static void ConfigureIISIntergration(this IServiceCollection services)
            => services.Configure<IISOptions>(
                options =>
                {

                }
                );
        public static void ConfigureLoggerService(this IServiceCollection services) =>
        services.AddSingleton<ILoggerManager, LoggerManager>();


    }
}
