using Domain.Enums;
using Microsoft.AspNetCore.Authorization;

namespace Infrastructure.Authentication;

public sealed class HasPasePermissionAttribute : AuthorizeAttribute
{
    public HasPasePermissionAttribute(PasePermissionEnum permission)
        : base(policy: permission.ToString()) { }
}
