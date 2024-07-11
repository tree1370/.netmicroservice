using System.Security.Claims;

namespace Building.Blocks.Core.Extensions;

public static class ClaimsPrincipalExtensions
{
    public static string GetClaimValue(this ClaimsPrincipal principal, string type)
    {
        return principal.FindFirst(type)!.Value;
    }
}
