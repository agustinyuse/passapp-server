using Application.Abstractions;
using Application.Abstractions.Data;
using Infrastructure.Authentication;
using Infrastructure.Persistance;
using Infrastructure.Persistance.Filters;
using Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Infrastructure;
public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration, bool IsDevelopment)
    {
        services.AddScoped<IJwtProvider, JwtProvider>();
        services.AddScoped<IPermissionService, PermissionService>();
        services.AddScoped<IUserProvider, UserProvider>();
        services.AddScoped<IEmailService, EmailService>();

        services.AddDbContext<IApplicationDbContext, ApplicationDbContext>(option =>
        {
            if (IsDevelopment)
            {
                option.EnableSensitiveDataLogging();
                option.UseLoggerFactory(LoggerFactory.Create(builder =>
                {
                    builder.AddConsole();
                }));

                //option.UseInMemoryDatabase("TestDb");
            }

            option.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            option.UseSqlServer(configuration.GetConnectionString("Database")!, options =>
            {
                options.CommandTimeout(45);
                options.EnableRetryOnFailure();
            });
        });

        return services;
    }
}
