using Application.Abstractions.Data;
using Application.Abstractions.Messaging;
using Domain.Shared;
using Domain.Entities;
using Application.Abstractions;

namespace Application.Features.Pase.Commands;

public class CreateCommandHandler : ICommandHandler<CreateCommand>
{
    private readonly IApplicationDbContext _context;
    private readonly IEmailService _emailService;
    private readonly IUserProvider _userProvider;

    public CreateCommandHandler(IApplicationDbContext context,
        IEmailService emailService,
        IUserProvider userProvider)
    {
        _context = context;
        _emailService = emailService;
        _userProvider = userProvider;
    }

    public async Task<Result> Handle(CreateCommand request, CancellationToken cancellationToken)
    {
        Result<Domain.Entities.Pase> paseCreateResult = Domain.Entities.Pase.Create(request.OrganizationId,
            request.AreaId,
            request.Description);

        if (paseCreateResult.IsFailure)
        {
            return Result.Failure(paseCreateResult.Error);
        }

        Domain.Entities.Pase pase = paseCreateResult.Value();

        if (request.Users.Any())
        {
            foreach (var user in request.Users)
            {
                var userDb = _context.Users.Single(p => p.Email == user.Email);
                pase.Add(userDb.Id,
                    user.PasePermissionId);
            }

            pase.Add(_userProvider.GetCurrentUserId().Value,
                Domain.Enums.PasePermissionEnum.Owner);
        }

        await _context.Pases.AddAsync(pase);
        await _context.SaveChangesAsync(cancellationToken);

        if (request.IsNotification)
        {
            await _emailService.SendWelcomePaseAsync(pase);
        }

        return Result.Success();
    }
}
