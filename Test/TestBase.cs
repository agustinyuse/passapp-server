using Application.Abstractions.Data;
using Application.Features.Professional.Commands;
using Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.DependencyInjection;

namespace Test;

internal abstract class TestBase
{
    private readonly IServiceProvider _serviceProvider;

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

        services.AddTransient<IApplicationDbContext>(provider => provider.GetService<ApplicationDbContext>());
        services.AddTransient<CreateProfessionalCommandHandler>();


        _serviceProvider = services.BuildServiceProvider();
    }

    protected T GetService<T>()
    {
        return _serviceProvider.GetService<T>();
    }
}
