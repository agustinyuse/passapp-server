using Application.Abstractions.Messaging;

namespace Application.Features.Professional.Commands;

public sealed record CreateProfessionalCommand(
    string FirstName, 
    string LastName, 
    string Street, 
    string Number,
    string Floor,
    string Unit,
    string ZipCode,
    string AdjacentStreet1,
    string AdjacentStreet2,
    string City,
    string State, 
    string Country): ICommand;
