namespace Stroyzaschita.Application.Common.Interfaces.Auth;

public interface IJwtTokenGenerator {
    string GenerateToken(Guid userId, string login, string role);
}
