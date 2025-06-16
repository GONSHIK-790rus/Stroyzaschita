using Stroyzaschita.Shared.DTOs.User;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Stroyzaschita.UI.Contexts;

public class AuthContext {
    public Guid? UserId { get; private set; }
    public string? Role { get; private set; }
    public bool IsAuthenticated { get; set; } = false;
    public string? Token { get; set; }
    public UserDto? CurrentUser { get; set; }

    public void InitializeFromToken(string token) {
        var handler = new JwtSecurityTokenHandler();
        var jwt = handler.ReadJwtToken(token);

        var userId = jwt.Claims.FirstOrDefault(claim => claim.Type == ClaimTypes.NameIdentifier)?.Value;
        var role = jwt.Claims.FirstOrDefault(claim => claim.Type == ClaimTypes.Role)?.Value;

        if (Guid.TryParse(userId, out var id))
            UserId = id;

        Role = role;
        IsAuthenticated = true;
    }
}
