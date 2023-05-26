using Application;
using Application.Abstractions.Data;
using Application.Features.Professional.Commands;
using Infrastructure.Persistance;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.DependencyInjection;

namespace Test;

public abstract class TestBase
{
    public readonly IServiceProvider _serviceProvider;

    protected TestBase()
    {
        var services = new ServiceCollection();

        services.AddDbContext<ApplicationDbContext>(
            options =>
        options
        .UseInMemoryDatabase(databaseName: "TestDB")
        .EnableSensitiveDataLogging(true)
        .ConfigureWarnings(
            w =>
            w.Ignore(InMemoryEventId.TransactionIgnoredWarning)));

        services.AddScoped<IApplicationDbContext>(provider => provider.GetService<ApplicationDbContext>());

        services.AddHttpContextAccessor();

        services.AddApplication();

        services.Configure<ApiBehaviorOptions>(options => options.SuppressModelStateInvalidFilter = true);

        _serviceProvider = services.BuildServiceProvider();
    }

    protected T GetService<T>()
    {
        return _serviceProvider.GetService<T>();
    }
}
