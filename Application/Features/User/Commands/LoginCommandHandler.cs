using Application.Abstractions;
using Application.Abstractions.Messaging;
using Domain.Shared;

namespace Application.Features.User.Commands;

internal sealed class LoginCommandHandler : ICommandHandler<LoginCommand, string>
{
    private readonly IJwtProvider _jwtProvider;

    public LoginCommandHandler(IJwtProvider jwtProvider)
    {
        _jwtProvider = jwtProvider;
    }

    public async Task<Result<string>> Handle(
        LoginCommand request,
        CancellationToken cancellationToken)
    {
        string token = _jwtProvider.Generate(new Domain.Entities.User() { UserId = 1 });

        return token;
    }
}
