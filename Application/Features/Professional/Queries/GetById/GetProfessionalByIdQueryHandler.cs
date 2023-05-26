using Application.Abstractions.Data;
using Application.Abstractions.Messaging;
using Domain.Shared;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Professional.Queries.GetById;

internal sealed class GetProfessionalByIdQueryHandler : IQueryHandler<GetProfessionalByIdQuery, ProfessionalResponse>
{
    private readonly IApplicationDbContext _context;

    public GetProfessionalByIdQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Result<ProfessionalResponse>> Handle(GetProfessionalByIdQuery request, CancellationToken cancellationToken)
    {
        var professional = _context
            .Professionals
            .Include(p => p.Addresses)
            .SingleOrDefault(p => p.Id == request.Id);

        if (professional is null)
        {
            return Result.Failure<ProfessionalResponse>(new Error(
              "Professional.NotFound",
              $"The professional with Id {request.Id} was not found"));
        }

        var addresses = professional
            .Addresses?
            .Select(AddressHelper.GetFullAddressDescription)
            .ToList();

        var response = new ProfessionalResponse(professional.Id,
            professional.FirstName,
            professional.LastName,
            addresses);

        return response;
    }
}
