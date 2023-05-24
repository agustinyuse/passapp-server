using Application.Abstractions.Data;
using Domain.Entities;
using Domain.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Infrastructure.Persistance;

public class ApplicationDbContext : DbContext, IApplicationDbContext
{
    private readonly string? _userId;
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options,
        IHttpContextAccessor accessor) : base(options)
    {
        _userId = accessor.HttpContext?
            .User.Claims.FirstOrDefault(x =>
                x.Type == JwtRegisteredClaimNames.Sid)?.Value;
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
        int userId = 0;

        if (!int.TryParse(_userId, out userId))
        {
            throw new Exception();
        }

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
}
