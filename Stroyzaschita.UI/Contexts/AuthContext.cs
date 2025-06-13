using Stroyzaschita.Shared.DTOs.User;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Stroyzaschita.UI.Contexts;

public class AuthContext {
    public bool IsAuthenticated { get; set; } = false;
    public string? Token { get; set; }
    public string? Role { get; set; }
    public UserDto? CurrentUser { get; set; }

    public void InitializeFromToken(string jwt) {
        Token = jwt;
        IsAuthenticated = true;

        var handler = new JwtSecurityTokenHandler();
        var jwtToken = handler.ReadJwtToken(jwt);

        Role = jwtToken.Claims
            .FirstOrDefault(claim => claim.Type == ClaimTypes.Role)
            ?.Value;
    }
}
