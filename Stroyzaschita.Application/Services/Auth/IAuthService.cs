namespace Stroyzaschita.Application.Services.Auth;

using Stroyzaschita.Shared.DTOs.Auth;

public interface IAuthService {
    Task RegisterAsync(RegisterRequest registerRequest);
    Task<LoginResponse> LoginAsync(LoginRequest loginRequest);
}
