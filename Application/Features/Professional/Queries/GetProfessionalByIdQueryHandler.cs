using Application.Abstractions.Messaging;
using Domain.Shared;

namespace Application.Features.Professional.Queries;

internal sealed class GetProfessionalByIdQueryHandler : IQueryHandler<GetProfessionalByIdQuery, ProfessionalResponse>
{
    public async Task<Result<ProfessionalResponse>> Handle(GetProfessionalByIdQuery request, CancellationToken cancellationToken)
    {
        var response = new ProfessionalResponse(1, "Agustin", "Yuse", "Av. Sarmiento 230 1/J, Chivilcoy, Buenos Aires, Argentina");

        return response;
    }
}
