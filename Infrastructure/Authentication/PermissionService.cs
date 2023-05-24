using Application.Abstractions.Data;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Authentication;

public class PermissionService : IPermissionService
{
    private readonly IApplicationDbContext _context;

    public PermissionService(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<HashSet<string>> GetPermissionsAsync(int userId)
    {
        try
        {
            ICollection<RolePermission> roles = await _context.UserRoles
                .Include(p => p.Role)
                 .ThenInclude(p => p.Permissions)
                 .ThenInclude(p => p.Permission)
                .Where(p => p.UserId == userId)
                .SelectMany(p => p.Role.Permissions)
                .ToArrayAsync();



            return roles.Select(x => x.Permission.Name)
                        .ToHashSet();

        }
        catch (Exception ex)
        {

            throw;
        }

    }
}
