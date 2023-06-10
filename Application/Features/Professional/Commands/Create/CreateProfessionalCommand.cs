using Application.Abstractions.Messaging;

namespace Application.Features.Professional.Commands.Create;

public sealed record CreateProfessionalCommand(
    string FirstName,
    string LastName,
    bool withAddress = false,
    string? Address = null,
    string? ZipCode = null,
    string? City = null,
    string? State = null,
    string? Country = null) : ICommand;
