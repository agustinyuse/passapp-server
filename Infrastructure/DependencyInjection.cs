
using Application.Abstractions.Data;
using Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

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

                    option.UseInMemoryDatabase("testDb");

                    //option.UseSqlServer(builder.Configuration.GetConnectionString("SqlServerConnection"), options =>
                    //{
                    //    options.CommandTimeout(45);
                    //    options.EnableRetryOnFailure();
                    //});
                });

        services.AddScoped<IApplicationDbContext, ApplicationDbContext>();

        return services;
    }
}
