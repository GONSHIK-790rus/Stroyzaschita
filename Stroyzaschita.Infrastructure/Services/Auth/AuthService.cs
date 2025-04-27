using System.Security.Cryptography;
using System.Text;
using Stroyzaschita.Application.Services.Auth;
using Stroyzaschita.Domain.Entities;
using Stroyzaschita.Domain.Enums;
using Stroyzaschita.Domain.Repositories;
using Stroyzaschita.Shared.DTOs.Auth;

namespace Stroyzaschita.Infrastructure.Services.Auth;

class AuthService : IAuthService {
    private readonly IUserRepository _IUserRepository;

    public AuthService(IUserRepository IUserRepository) {
        _IUserRepository = IUserRepository;
    }

    public async Task<LoginResponse> LoginAsync(LoginRequest loginRequest) {
        User? user = await _IUserRepository.GetByLoginAsync(loginRequest.Login)
            ?? throw new Exception("Неверный логин или пароль");
        
        if (user.PasswordHash != HashPassword(loginRequest.Password, user.PasswordSalt))
            throw new Exception("Неверный логин или пароль");

        return new LoginResponse {
            Token = "temp", // Пока заглушка
            UserId = user.Id,
            Login = user.Login
        };
    }

    public async Task<LoginResponse> RegisterAsync(RegisterRequest registerRequest) {
        if (await _IUserRepository.IsUserExistsAsync(registerRequest.Login))
            throw new Exception("Пользователь с таким логином уже существует");

        string passwordSalt = GenerateSalt();

        User user = new User {
            Login = registerRequest.Login,
            PasswordHash = HashPassword(registerRequest.Password, passwordSalt),
            PasswordSalt = passwordSalt,
            Role = UserRole.Customer,

            UserProfile = new UserProfile {
                Name = registerRequest.Name,
                ObjectName = registerRequest.ObjectName,
                PhoneNumber = registerRequest.PhoneNumber
            }
        };

        await _IUserRepository.AddUserAsync(user);

        return new LoginResponse {
            Token = "temp", // Пока заглушка
            UserId = user.Id,
            Login = user.Login
        };
    }

    private static string HashPassword(string password, string passwordSalt) {
        using SHA512? sha512 = SHA512.Create();
        byte[]? passwordAndSaltBytes = Encoding.UTF8.GetBytes(password + passwordSalt);
        byte[]? passwordHash = sha512.ComputeHash(passwordAndSaltBytes);
        return Convert.ToBase64String(passwordHash);
    }

    private static string GenerateSalt() {
        byte[] saltBytes = new byte[32];
        using RandomNumberGenerator randomNumberGenerator = RandomNumberGenerator.Create();
        randomNumberGenerator.GetBytes(saltBytes);
        return Convert.ToBase64String(saltBytes);
    }
}
