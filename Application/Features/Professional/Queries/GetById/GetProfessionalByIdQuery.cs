using Application.Abstractions.Messaging;

namespace Application.Features.Professional.Queries.GetById;

public sealed record GetProfessionalByIdQuery(int Id) : IQuery<ProfessionalResponse>;


