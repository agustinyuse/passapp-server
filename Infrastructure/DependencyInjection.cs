using Application.Abstractions;
using Application.Abstractions.Data;
using Domain.Entities;
using Infrastructure.Authentication;
using Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using static System.Formats.Asn1.AsnWriter;

namespace Infrastructure;
public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration, bool IsDevelopment)
    {

        services.AddDbContext<ApplicationDbContext>(option =>
                {
                    if (IsDevelopment)
                    {
                        option.EnableSensitiveDataLogging();
                    }

                    option.UseInMemoryDatabase("TestDb");

                    var user = new User()
                    {
                        Email = "agustinyuse@gmail.com",
                        Id = 1
                    };

                    option.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
                   

                    //option.UseSqlServer(builder.Configuration.GetConnectionString("SqlServerConnection"), options =>
                    //{
                    //    options.CommandTimeout(45);
                    //    options.EnableRetryOnFailure();
                    //});
                });

        services.AddScoped<IApplicationDbContext>(sp => sp.GetRequiredService<ApplicationDbContext>());
        services.AddScoped<IJwtProvider, JwtProvider>();
        services.AddScoped<IPermissionService, PermissionService>();

        return services;
    }
}
