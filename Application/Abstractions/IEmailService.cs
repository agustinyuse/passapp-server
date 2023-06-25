using Domain.Entities;

namespace Application.Abstractions;

public interface IEmailService
{
    Task SendWelcomePaseAsync(Pase pase, 
        CancellationToken cancellationToken = default);
    Task SendNotificationWhenNewIntermentIsCreatedAsync(Internment internment,
        CancellationToken cancellationToken = default);
}
