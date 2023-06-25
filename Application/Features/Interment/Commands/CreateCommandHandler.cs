using Application.Abstractions;
using Application.Abstractions.Data;
using Application.Abstractions.Messaging;
using Domain.Shared;

namespace Application.Features.Interment.Commands;

internal class CreateCommandHandler : ICommandHandler<CreateCommand>
{
    private readonly IApplicationDbContext _context;
    private readonly IEmailService _emailService;

    public CreateCommandHandler(IApplicationDbContext context, 
        IEmailService emailService)
    {
        _context = context;
        _emailService = emailService;
    }

    public async Task<Result> Handle(CreateCommand request,
        CancellationToken cancellationToken)
    {
        Result<Domain.Entities.Internment> intermentResult = Domain.Entities.Internment.Create(request.patientId,
            request.bed,
            request.bedId);

        if (intermentResult.IsFailure)
        {
            return Result.Failure(intermentResult.Error);
        }

        Domain.Entities.Internment internment = intermentResult.Value();

        _context.Internments.Add(internment);
        await _context.SaveChangesAsync(cancellationToken);

        if (request.notify)
        {
            await _emailService.SendNotificationWhenNewIntermentIsCreatedAsync(internment, 
                cancellationToken);
        }

        return Result.Success();
    }
}
