using Domain.Entities;

namespace Application.Abstractions;

public interface IEmailService
{
    Task SendWelcomePaseAsync(Pase pase, CancellationToken cancellationToken = default);
}
