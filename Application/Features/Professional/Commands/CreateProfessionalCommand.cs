using Application.Abstractions.Messaging;

namespace Application.Features.Professional.Commands;

public sealed record CreateProfessionalCommand(
    string FirstName, 
    string LastName, 
    bool withAddress = false,
    string? Street = null, 
    string? Number = null,
    string? Floor = null,
    string? Unit = null,
    string? ZipCode = null,
    string? AdjacentStreet1 = null,
    string? AdjacentStreet2 = null,
    string? City = null,
    string? State = null, 
    string? Country = null): ICommand;
