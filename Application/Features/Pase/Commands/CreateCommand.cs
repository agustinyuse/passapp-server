using Application.Abstractions.Messaging;

namespace Application.Features.Pase.Commands;

public record CreateCommand(int OrganizationId,
    string Description,
    List<PaseUserPermissionRequestDto> Users,
    bool IsNotification = true) : ICommand;
