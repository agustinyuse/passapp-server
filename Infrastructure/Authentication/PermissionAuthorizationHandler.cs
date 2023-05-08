using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.JsonWebTokens;

namespace Infrastructure.Authentication;

public class PermissionAuthorizationHandler : AuthorizationHandler<PermissionRequirement>
{
    private readonly IServiceScopeFactory _scopeFactory;

    public PermissionAuthorizationHandler(IServiceScopeFactory scopeFactory)
    {
        _scopeFactory = scopeFactory;
    }

    protected override async Task HandleRequirementAsync(
        AuthorizationHandlerContext context,
        PermissionRequirement requirement)
    {
        string? userId = context.User.Claims.FirstOrDefault(x => x.Type == JwtRegisteredClaimNames.Sid)?.Value;

        if (!int.TryParse(userId, out int parsedUserId))
        {
            return;
        }

        using IServiceScope scope = _scopeFactory.CreateScope();

        IPermissionService permissionService = scope.ServiceProvider.GetRequiredService<IPermissionService>();

        HashSet<string> permissions = await permissionService.GetPermissionsAsync(parsedUserId);

        if (permissions.Contains(requirement.Permission))
        {
            context.Succeed(requirement);
        }
    }

    //protected override Task HandleRequirementAsync(
    //    AuthorizationHandlerContext context,
    //    PermissionRequirement requirement)
    //{
    //    HashSet<string> permissions = context.User.Claims.Where(x => x.Type == CustomClaims.Permissions).Select(x => x.Value).ToHashSet();

    //    if (permissions.Contains(requirement.Permission))
    //    {
    //        context.Succeed(requirement);
    //    }

    //    return Task.CompletedTask;
    //}
}
