using Application.Abstractions.Messaging;

namespace Application.Features.Pase.Commands;

public record CreateCommand(int OrganizationId,
    string Description,
    int? AreaId,
    List<PaseUserPermissionRequestDto> Users,
    bool IsNotification = true) : ICommand;
