using Application.Abstractions.Data;
using Application.Abstractions.Messaging;
using Domain.Shared;
using Domain.Entities;

namespace Application.Features.Professional.Commands.Create;

internal sealed class CreateProfessionalCommandHandler : ICommandHandler<CreateProfessionalCommand>
{
    private readonly IApplicationDbContext _context;

    public CreateProfessionalCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Result> Handle(CreateProfessionalCommand request, CancellationToken cancellationToken)
    {
        Result<Domain.Entities.Professional> professionalCreateResult = Domain.Entities.Professional.Create(request.FirstName,
            request.LastName);

        Domain.Entities.Professional professional = professionalCreateResult.Value();

        if (request.withAddress)
        {
            var result = professional.CreateProfessionalAddress(request.Street,
                   request.Number,
                   request.City,
                   request.State,
                   request.Country,
                   request.AdjacentStreet1,
                   request.AdjacentStreet2,
                   request.Floor,
                   request.Unit,
                   request.ZipCode);

            if (result.IsFailure)
            {
                return result;
            }
        }

        await _context.Professionals.AddAsync(professional);

        await _context.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}
