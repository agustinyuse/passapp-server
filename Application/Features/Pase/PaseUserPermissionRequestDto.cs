using Domain.Enums;

namespace Application.Features.Pase;

public record PaseUserPermissionRequestDto(string Email,
    PasePermissionEnum PasePermissionId);
