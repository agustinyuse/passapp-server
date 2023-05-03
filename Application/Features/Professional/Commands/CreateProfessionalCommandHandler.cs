using Application.Abstractions.Data;
using Application.Abstractions.Messaging;
using Domain.Entities;
using Domain.Shared;
using MediatR;

namespace Application.Features.Professional.Commands;

internal sealed class CreateProfessionalCommandHandler : ICommandHandler<CreateProfessionalCommand>
{
    private readonly IApplicationDbContext _context;

    public CreateProfessionalCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Result> Handle(CreateProfessionalCommand request, CancellationToken cancellationToken)
    {
        var professional = new Domain.Entities.Professional()
        {
            FirstName = request.FirstName,
            LastName = request.LastName,
        };

        await _context.Professionals.AddAsync(professional);

        await _context.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}
