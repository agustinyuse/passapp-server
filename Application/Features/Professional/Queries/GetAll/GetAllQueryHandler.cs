using Application.Abstractions.Data;
using Application.Abstractions.Messaging;
using Application.Features.Professional.Queries.GetById;
using Domain.Shared;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Professional.Queries.GetAll;

internal class GetAllQueryHandler : IQueryHandler<GetAllQuery, List<ProfessionalResponse>>
{
    private readonly IApplicationDbContext _context;

    public GetAllQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Result<List<ProfessionalResponse>>> Handle(GetAllQuery request, CancellationToken cancellationToken)
    {
        var professionalResponses = await _context.Professionals
                                    .Include(p => p.Addresses)
                                    .OrderBy(p => p.Id)
                                    .Skip((request.Page - 1) * request.PageSize)
                                    .Take(request.PageSize)
                                    .Select(p => new ProfessionalResponse(
                                        p.Id,
                                        p.FirstName,
                                        p.LastName,
                                        p.Addresses
                                            .Select(a => AddressHelper.GetFullAddressDescription(a))
                                            .DefaultIfEmpty()
                                            .ToList()
                                    ))
                                    .ToListAsync(cancellationToken);

        return professionalResponses;

    }
}
