using System.Security.Claims;
using Api.Models.Users;

namespace Api.Common.Interfaces;

public interface ITokenService
{
    ClaimsPrincipal GetPrincipalFromExpiredToken(string accessToken);
    string GenerateAccessToken(User user, Guid sessionId);
    string GenerateRefreshToken();
}