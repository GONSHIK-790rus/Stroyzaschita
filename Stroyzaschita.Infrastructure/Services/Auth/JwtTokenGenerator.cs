using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Stroyzaschita.Application.Common.Interfaces.Auth;
using Stroyzaschita.Application.Common.Settings;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Stroyzaschita.Infrastructure.Services.Auth;

public class JwtTokenGenerator : IJwtTokenGenerator {
    private readonly JwtSettings _jwtSettings;

    public JwtTokenGenerator(IOptions<JwtSettings> jwtSettings) {
        _jwtSettings = jwtSettings.Value;
    }

    public string GenerateToken(Guid userId, string login, string role) {
        Claim[] claims = [
            new Claim(JwtRegisteredClaimNames.Sub, userId.ToString()),
            new Claim(JwtRegisteredClaimNames.UniqueName, login),
            new Claim(ClaimTypes.Role, role)
        ];

        SymmetricSecurityKey symmetricSecurityKey = new (Encoding.UTF8.GetBytes(_jwtSettings.SecretKey));
        SigningCredentials signingCredentials = new (symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

        JwtSecurityToken token = new (
            issuer: _jwtSettings.Issuer,
            audience: _jwtSettings.Audience,
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(_jwtSettings.ExpiryMinutes),
            signingCredentials: signingCredentials
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
