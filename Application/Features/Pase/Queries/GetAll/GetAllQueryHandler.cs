using Application.Abstractions.Data;
using Application.Abstractions.Messaging;
using Domain.Shared;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Pase.Queries.GetAll;

internal class GetAllQueryHandler : IQueryHandler<GetAllQuery, List<PaseResponse>>
{
    private readonly IApplicationDbContext _context;

    public GetAllQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Result<List<PaseResponse>>> Handle(GetAllQuery request, CancellationToken cancellationToken)
    {
        return await _context
        .Pases
        .Select(p =>
        new PaseResponse(
            p.Organization.Name,
            p.Name))
        .ToListAsync(cancellationToken);
    }
}
