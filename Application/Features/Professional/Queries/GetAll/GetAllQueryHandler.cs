using Application.Abstractions.Data;
using Application.Abstractions.Messaging;
using Application.Features.Professional.Queries.GetById;
using Domain.Shared;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        return await _context.Professionals
            .Include(p => p.Addresses)
                .Select(p => new ProfessionalResponse(
                p.Id,
                p.FirstName,
                p.LastName,
                p.Addresses
                .Select(a => AddressHelper.GetFullAddressDescription(a))
                .ToList()
            ))
        .ToListAsync();
    }
}
