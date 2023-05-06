using Microsoft.EntityFrameworkCore;
using Domain.Entities;

namespace Application.Abstractions.Data;

public interface IApplicationDbContext
{
    DbSet<Professional> Professionals { get; set; }
    DbSet<User> Users { get; set; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
