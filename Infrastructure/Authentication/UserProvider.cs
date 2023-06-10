using Application.Abstractions;
using Application.Abstractions.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using System.IdentityModel.Tokens.Jwt;

namespace Infrastructure.Authentication;

public class UserProvider : IUserProvider
{
    private readonly IHttpContextAccessor _contextAccessor;
    private readonly IApplicationDbContext _applicationDbContext;
    private readonly IMemoryCache _cache;

    public UserProvider(IHttpContextAccessor contextAccessor,
        IApplicationDbContext applicationDbContext,
        IMemoryCache cache)
    {
        _contextAccessor = contextAccessor;
        _applicationDbContext = applicationDbContext;
        _cache = cache;
    }

    public async Task<int> GetCurrentUserId()
    {
        string? userIdClaim = _contextAccessor.HttpContext?
           .User.Claims.FirstOrDefault(x =>
               x.Type == JwtRegisteredClaimNames.Sid)?.Value;

        if (!int.TryParse(userIdClaim, out int userId))
        {
            // Handle the case when the user ID is not available or not valid
            // For example, you can log an error or throw an exception.
            throw new Exception("Unable to retrieve the current user ID.");
        }

        var cacheUserKey = $"CacheUser_{userId}";
        int? user = _cache.Get<int?>(cacheUserKey);

        if (user is null)
        {
            if (!_applicationDbContext.Users.Any(p => p.Id == userId))
            {
                throw new UnauthorizedAccessException($"User '{userId}' is not registered.");
            }

            var entity = await _applicationDbContext.Users
             .FirstOrDefaultAsync(q => q.Id == userId)
                 ?? throw new ArgumentException($"User '{userId}' is not registered.");

            _cache.Set(cacheUserKey, userId);
        }

        return user.Value;
    }
}
