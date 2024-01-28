using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BookingServices.Core.Identity;

public class JwtTokenGenerator
{
    public static string GenerateJwtToken(string secretKey, string userId, string issuer, string audience, List<string> roles,
        int expirationMinutes = 60, string email = "", string userName = "", string fullName = "", IDictionary<string, string>? extension = null)
    {
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var claims = new List<Claim>
        {
        new Claim(JwtRegisteredClaimNames.Sub, userId),
        new Claim(JwtRegisteredClaimNames.Email, email),
        new Claim("username", userName),
        new Claim(JwtRegisteredClaimNames.Name, fullName),
        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
        new Claim(JwtRegisteredClaimNames.Iat, DateTimeOffset.Now.ToUnixTimeSeconds().ToString(), ClaimValueTypes.Integer64)
        // Add more custom claims as needed
        };

        // Add extension claims
        if (extension != null && extension.Count > 0)
        {
            claims.AddRange(extension.Select(item => new Claim(item.Key, item.Value)));
        }
        // Add roles to claims
        if (roles != null && roles.Count > 0)
        {
            claims.AddRange(roles.Select(role => new Claim(ClaimTypes.Role, role)));
        }

        var token = new JwtSecurityToken(
            issuer: issuer,
            audience: audience,
            claims: claims,
            expires: DateTime.Now.AddMinutes(expirationMinutes),
            signingCredentials: creds
        );

        var tokenHandler = new JwtSecurityTokenHandler();
        return tokenHandler.WriteToken(token);
    }
}
