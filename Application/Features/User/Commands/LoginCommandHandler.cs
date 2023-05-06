using Application.Abstractions.Messaging;
using Domain.Shared;

namespace Application.Features.User.Commands;

internal sealed class LoginCommandHandler : ICommandHandler<LoginCommand, string>
{
    public Task<Result<string>> Handle(
        LoginCommand request, 
        CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
