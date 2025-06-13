namespace Stroyzaschita.UI.Interfaces;

public interface IAuthService {
    bool IsAuthorized();
    string? GetCurrentLogin();
    string? GetCurrentRole();
}
