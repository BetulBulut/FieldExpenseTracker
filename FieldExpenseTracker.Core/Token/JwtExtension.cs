using System.Security.Claims;
using FieldExpenseTracker.Core.Session;
using Microsoft.AspNetCore.Http;

namespace FieldExpenseTracker.Core.Token;

public static class JwtManager
{
    public static AppSession GetSession(HttpContext context)
    {
        AppSession session = new AppSession();
        var identity = context?.User?.Identity as ClaimsIdentity;
        if (identity == null)
            return session;

        var claims = identity.Claims;
        session.UserName = GetClaimValue(claims, "UserName");
        session.UserId = GetClaimValue(claims, "UserId");
        session.UserRole = GetClaimValue(claims, "Role");
        session.FirstName = GetClaimValue(claims, "FirstName");
        session.LastName = GetClaimValue(claims, "LastName");
        session.EmployeeId = int.TryParse(GetClaimValue(claims, "EmployeeId"), out var employeeId) ? employeeId : 0;
        session.Token = context.Request.Headers["Authorization"].ToString().Replace("Bearer ", "");
        session.HttpContext = context;
        return session;
    }

    private static string GetClaimValue(IEnumerable<Claim> claims, string name)
    {
        var claim = claims.FirstOrDefault(c => c.Type == name);
        return claim?.Value;
    }
}