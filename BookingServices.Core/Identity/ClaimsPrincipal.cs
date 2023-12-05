using System.Security.Authentication;
using System.Security.Claims;

namespace BookingServices.Core.Identity;

public class ClaimsPrincipalExtension
{
    //new Claim(JwtRegisteredClaimNames.Sub, userId)
    //new Claim(JwtRegisteredClaimNames.Email, email)
    //new Claim(JwtRegisteredClaimNames.NameId, userName)
    //new Claim(JwtRegisteredClaimNames.Name, fullName)
    //generate funtions to get claims from token
    public static Guid GetUserId(ClaimsPrincipal? claimsPrincipal)
    {
        var userId = claimsPrincipal?.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;
        if (string.IsNullOrEmpty(userId))
        {
            throw new AuthenticationException("User not found");
        }
        return Guid.Parse(userId);
    }
    public static string GetEmail(ClaimsPrincipal? claimsPrincipal)
    {
        var email = claimsPrincipal?.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Email)?.Value;
        if (string.IsNullOrEmpty(email))
        {
            throw new AuthenticationException("Email not found");
        }
        return email;
    }
    public static string GetUserName(ClaimsPrincipal? claimsPrincipal)
    {
        var userName = claimsPrincipal?.Claims.FirstOrDefault(x => x.Type == "username")?.Value;
        if (string.IsNullOrEmpty(userName))
        {
            throw new AuthenticationException("UserName not found");
        }
        return userName;
    }
    public static string GetFullName(ClaimsPrincipal? claimsPrincipal)
    {
        var fullName = claimsPrincipal?.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Name)?.Value;
        if (string.IsNullOrEmpty(fullName))
        {
            throw new AuthenticationException("FullName not found");
        }
        return fullName;
    }
    public static string GetRole(ClaimsPrincipal? claimsPrincipal)
    {
        var role = claimsPrincipal?.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Role)?.Value;
        if (string.IsNullOrEmpty(role))
        {
            throw new AuthenticationException("Role not found");
        }
        return role;
    }

    //function for extension claims with key type string and value type string
    public static string GetExtensionString(ClaimsPrincipal? claimsPrincipal, string key)
    {
        var extension = claimsPrincipal?.Claims.FirstOrDefault(x => x.Type == key)?.Value;
        if (string.IsNullOrEmpty(extension))
        {
            throw new AuthenticationException("Extension not found");
        }
        return extension;
    }


}
