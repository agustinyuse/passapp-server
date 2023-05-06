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
        ICollection<Role>[] roles = await _context.Users
                                                        .Include(p => p.Roles)
                                                        .ThenInclude(p => p.Permissions)
                                                        .Where(p => p.UserId == userId)
                                                        .Select(p => p.Roles)
                                                        .ToArrayAsync();
        return roles.SelectMany(x => x)
                    .SelectMany(x => x.Permissions)
                    .Select(x => x.Name)
                    .ToHashSet();
    }
}
