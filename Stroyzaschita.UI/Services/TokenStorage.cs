using Blazored.LocalStorage;

namespace Stroyzaschita.UI.Services;

public class TokenStorage {
    private const string TokenKey = "authToken";
    private readonly ILocalStorageService _storageService;

    public TokenStorage(ILocalStorageService storageService) {
        _storageService = storageService;
    }

    public async Task SetTokenAsync(string token) {
        await _storageService.SetItemAsync(TokenKey, token);
    }

    public async Task<string?> GetTokenAsync() {
        return await _storageService.GetItemAsync<string>(TokenKey);
    }

    public async Task RemoveTokenAsync() {
        await _storageService.RemoveItemAsync(TokenKey);
    }
}