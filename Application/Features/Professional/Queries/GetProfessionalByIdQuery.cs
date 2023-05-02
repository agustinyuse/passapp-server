using Application.Abstractions.Messaging;

namespace Application.Features.Professional.Queries;

public sealed record GetProfessionalByIdQuery(int Id) : IQuery<ProfessionalResponse>;


