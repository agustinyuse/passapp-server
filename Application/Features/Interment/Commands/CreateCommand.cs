using Application.Abstractions.Messaging;

namespace Application.Features.Interment.Commands;

public record CreateCommand(int paseId,
    int patientId,
    string bed,
    int? bedId,
    bool notify) : ICommand;