using Application.Abstractions.Messaging;

namespace Application.Features.Professional.Commands;

public sealed record CreateProfessionalCommand(
    string FirstName, 
    string LastName, 
    string Address, 
    int CityId,
    int StateId, 
    int Country): ICommand;
