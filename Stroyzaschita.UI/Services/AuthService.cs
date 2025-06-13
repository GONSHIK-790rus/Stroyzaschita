using Stroyzaschita.UI.Contexts;
using Stroyzaschita.UI.Interfaces;

namespace Stroyzaschita.UI.Services;

public class AuthService : IAuthService {
    private readonly AuthContext _authContext;

    public AuthService(AuthContext authContext) {
        _authContext = authContext;
    }

    public bool IsAuthorized() {
        return _authContext.IsAuthenticated;
    }

    public string? GetCurrentLogin() {
        return _authContext.CurrentUser?.Login;
    }

    public string? GetCurrentRole() {
        return _authContext.CurrentUser?.Role;
    }
}
