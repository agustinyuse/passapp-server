using Microsoft.EntityFrameworkCore;
using Domain.Entities;

namespace Application.Abstractions.Data;

public interface IApplicationDbContext
{
    DbSet<Professional> Professionals { get; set; }
    DbSet<User> Users { get; set; }
    DbSet<Role> Roles { get; set; }
    DbSet<Permission> Permissions { get; set; }
    DbSet<RolePermission> RolePermissions { get; set; }
    public DbSet<UserRole> UserRoles { get; set; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
