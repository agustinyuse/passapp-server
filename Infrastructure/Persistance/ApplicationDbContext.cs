using Application.Abstractions;
using Application.Abstractions.Data;
using Domain.Entities;
using Domain.Shared;
using Infrastructure.Authentication;
using Infrastructure.Persistance.Filters;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;

namespace Infrastructure.Persistance;

public class ApplicationDbContext : DbContext, IApplicationDbContext
{
    private readonly IUserProvider _userProvider;
    private int? _currentUserId;
    public int? CurrentUserId
    {
        get => _currentUserId ?? _userProvider.GetCurrentUserId();
        set => _currentUserId = value;
    }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options,
        IUserProvider userProvider) : base(options)
    {
        _userProvider = userProvider;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

        modelBuilder.Entity<Pase>()
                   .HasQueryFilter(p => p.CreatedUserId == CurrentUserId ||
                                         p.UserPermissions.Any(q => q.UserId == CurrentUserId));
        base.OnModelCreating(modelBuilder);
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        AuditableEntities();

        return await base.SaveChangesAsync(cancellationToken);
    }

    private void AuditableEntities()
    {
        if (CurrentUserId is null && CurrentUserId == 0){
            throw new UnauthorizedAccessException($"User '{CurrentUserId}' is not registered.");
        }

        foreach (var entry in ChangeTracker.Entries<BaseEntity>())
        {
            switch (entry.State)
            {
                case EntityState.Added:
                    entry.Entity.CreatedUserId = CurrentUserId.Value;
                    entry.Entity.DateCreated = DateTime.UtcNow;

                    break;

                case EntityState.Modified:
                    entry.Entity.UpdatedUserId = CurrentUserId;
                    entry.Entity.DateUpdated = DateTime.UtcNow;
                    break;
            }
        }
    }

    public DbSet<Professional> Professionals { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<Permission> Permissions { get; set; }
    public DbSet<RolePermission> RolePermissions { get; set; }
    public DbSet<UserRole> UserRoles { get; set; }
    public DbSet<Organization> Organizations { get; set; }
    public DbSet<Pase> Pases { get; set; }
    public DbSet<PaseUserPasePermission> PaseUserPasePermissions { get; set; }
    public DbSet<PasePermission> PasePermissions { get; set; }
}
