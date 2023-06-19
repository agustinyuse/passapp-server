using Application.Abstractions.Messaging;

namespace Application.Features.Pase.Queries.GetAll;

public record GetAllQuery() : IQuery<List<PaseResponse>>;
