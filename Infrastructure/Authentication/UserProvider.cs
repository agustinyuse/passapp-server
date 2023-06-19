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

    public UserProvider(IHttpContextAccessor contextAccessor)
    {
        _contextAccessor = contextAccessor;
    }

    public int? GetCurrentUserId()
    {
        string? userIdClaim = _contextAccessor.HttpContext?
           .User.Claims.FirstOrDefault(x =>
               x.Type == JwtRegisteredClaimNames.Sid)?.Value;

        int.TryParse(userIdClaim, out int userId);

        return userId;
    }
}
