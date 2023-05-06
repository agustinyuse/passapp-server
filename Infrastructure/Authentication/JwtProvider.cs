using Application.Abstractions;
using Domain.Entities;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Infrastructure.Authentication;

public class JwtProvider : IJwtProvider
{
    private readonly JwtOptions _options;

    public JwtProvider(IOptions<JwtOptions> options)
    {
        _options = options.Value;
    }

    public string Generate(User user)
    {
        var claims = new Claim[] {
         new(JwtRegisteredClaimNames.Sub, user.UserId.ToString()),
        };

        var signingCredentials = new SigningCredentials(
            new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_options.SecretKey)),
            SecurityAlgorithms.HmacSha256);


        var token = new JwtSecurityToken(_options.Issuer, _options.Audiencie, claims, null, DateTime.UtcNow.AddMinutes(15), signingCredentials);

        var tokenValue = new JwtSecurityTokenHandler().WriteToken(token);

        return tokenValue;
    }

    //todo: tener los permisos en el token
    //public async Task<string> Generate(User user)
    //{
    //    var claims = new List<Claim> {
    //     new(JwtRegisteredClaimNames.Sub, user.UserId.ToString()),
    //    };

    //    HashSet<string> permissions = await _permissionService.GetPermissionsAsync(user.UserId);

    //    foreach (var permission in permissions)
    //    {
    //        claims.Add(new(CustomClaims.Permissions, permission));
    //    }

    //    var signingCredentials = new SigningCredentials(
    //        new SymmetricSecurityKey(
    //            Encoding.UTF8.GetBytes(_options.SecretKey)),
    //        SecurityAlgorithms.HmacSha256);


    //    var token = new JwtSecurityToken(_options.Issuer, _options.Audiencie, claims, null, DateTime.UtcNow.AddMinutes(15), signingCredentials);


    //    var tokenValue = new JwtSecurityTokenHandler().WriteToken(token);

    //    return tokenValue;
    //}
}

