namespace Application.Features.Professional.Queries.GetById;

public sealed record ProfessionalResponse(
 int Id,
 string FirstName,
 string LastName,
 List<string>? FullAddress);
