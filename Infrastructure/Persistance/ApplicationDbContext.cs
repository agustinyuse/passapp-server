using Application.Abstractions;
using Application.Abstractions.Data;
using Domain.Entities;
using Domain.Shared;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistance;

public class ApplicationDbContext : DbContext, IApplicationDbContext
{
    private readonly IUserProvider _userProvider;

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options,
        IUserProvider userProvider) : base(options)
    {
        _userProvider = userProvider;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
    }

    protected override void OnConfiguring
      (DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseInMemoryDatabase(databaseName: "TestDb");
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        int userId = await _userProvider.GetCurrentUserId();

        foreach (var entry in ChangeTracker.Entries<BaseEntity>())
        {
            switch (entry.State)
            {
                case EntityState.Added:
                    entry.Entity.CreatedUserId = userId;
                    entry.Entity.DateCreated = DateTime.UtcNow;

                    break;

                case EntityState.Modified:
                    entry.Entity.UpdatedUserId = userId;
                    entry.Entity.DateUpdated = DateTime.UtcNow;
                    break;
            }
        }

        return await base.SaveChangesAsync(cancellationToken);
    }

    public DbSet<Professional> Professionals { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<Permission> Permissions { get; set; }
    public DbSet<RolePermission> RolePermissions { get; set; }
    public DbSet<UserRole> UserRoles { get; set; }
    public DbSet<Organism> Organizations { get; set; }
}
