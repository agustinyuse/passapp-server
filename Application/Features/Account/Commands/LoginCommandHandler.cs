using Application.Abstractions;
using Application.Abstractions.Data;
using Application.Abstractions.Messaging;
using Domain.Shared;

namespace Application.Features.Account.Commands;

internal sealed class LoginCommandHandler : ICommandHandler<LoginCommand, string>
{
    private readonly IJwtProvider _jwtProvider;
    private readonly IApplicationDbContext _dbContext;

    public LoginCommandHandler(IJwtProvider jwtProvider,
        IApplicationDbContext dbContext)
    {
        _jwtProvider = jwtProvider;
        _dbContext = dbContext;
    }

    public async Task<Result<string>> Handle(
        LoginCommand request,
        CancellationToken cancellationToken)
    {
        var user = _dbContext.Users.SingleOrDefault(p => p.Email == request.Email);
        if (user == null)
        {
            return Result.Failure<string>(new Error("Error login", "Not Authorized"));
        }

        string token = _jwtProvider.Generate(user);

        return token;
    }
}
