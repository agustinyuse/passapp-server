using Application.Abstractions;
using Domain.Entities;

namespace Infrastructure.Services;

internal sealed class EmailService : IEmailService
{
    public Task SendNotificationWhenNewIntermentIsCreatedAsync(Internment internment, 
        CancellationToken cancellationToken = default) => Task.CompletedTask;

    public Task SendWelcomePaseAsync(Pase pase,
        CancellationToken cancellationToken = default) => 
        Task.CompletedTask;
}
