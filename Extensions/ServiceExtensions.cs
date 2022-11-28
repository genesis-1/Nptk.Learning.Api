using Microsoft.EntityFrameworkCore;
using Nptk.Learning.Contracts;
using Nptk.Learning.LoggerSerice;
using Nptk.Learning.Repository;
using Nptk.Learning.Service.Contracts;

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

        public static void ConfigureSqlContext(this IServiceCollection services, IConfiguration configuration) =>
        services.AddDbContext<RepositoryContext>(opts =>
            opts.UseSqlServer(configuration.GetConnectionString("sqlConnection")));

        public static void ConfigureRepositoryManager(this IServiceCollection services) =>
        services.AddScoped<IRepositoryManager, RepositoryManager>();

        public static void ConfigureServiceManager(this IServiceCollection services) =>
        services.AddScoped<IServiceManager, Service.ServiceManager>();



    }
}
