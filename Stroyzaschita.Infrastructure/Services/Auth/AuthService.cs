using System.Security.Cryptography;
using System.Text;
using Stroyzaschita.Application.Common.Interfaces.Auth;
using Stroyzaschita.Application.Exceptions;
using Stroyzaschita.Application.Services.Auth;
using Stroyzaschita.Domain.Entities;
using Stroyzaschita.Domain.Repositories;
using Stroyzaschita.Shared.DTOs.Auth;

namespace Stroyzaschita.Infrastructure.Services.Auth;

public class AuthService : IAuthService {
    private readonly IUserRepository _userRepository;
    private readonly IJwtTokenGenerator _jwtTokenGenerator;

    public AuthService(IUserRepository userRepository, IJwtTokenGenerator jwtTokenGenerator) {
        _userRepository = userRepository;
        _jwtTokenGenerator = jwtTokenGenerator;
    }

    public async Task<LoginResponse> LoginAsync(LoginRequest loginRequest) {
        User? user = await _userRepository.GetByLoginAsync(loginRequest.Login)
            ?? throw new InvalidAccountDataException();

        if (user.PasswordHash != HashPassword(loginRequest.Password, user.PasswordSalt))
            throw new InvalidAccountDataException();

        return new LoginResponse {
            Token = _jwtTokenGenerator.GenerateToken(user.Id, user.Login, user.Role.Name),
            Login = user.Login
        };
    }

    public async Task RegisterAsync(RegisterRequest registerRequest) {
        if (await _userRepository.IsUserExistsAsync(registerRequest.Login))
            throw new UserAlreadyExistsException();

        string passwordSalt = GenerateSalt();

        User user = new() {
            Login = registerRequest.Login,
            PasswordHash = HashPassword(registerRequest.Password, passwordSalt),
            PasswordSalt = passwordSalt,

            UserProfile = new UserProfile {
                Name = registerRequest.Name,
                ObjectName = registerRequest.ObjectName,
                PhoneNumber = registerRequest.PhoneNumber
            }
        };

        await _userRepository.AddUserAsync(user);
    }

    private static string HashPassword(string password, string passwordSalt) {
        byte[]? passwordAndSaltBytes = Encoding.UTF8.GetBytes(password + passwordSalt);
        byte[]? passwordHash = SHA512.HashData(passwordAndSaltBytes);
        return Convert.ToBase64String(passwordHash);
    }

    private static string GenerateSalt() {
        byte[] saltBytes = new byte[32];
        using RandomNumberGenerator randomNumberGenerator = RandomNumberGenerator.Create();
        randomNumberGenerator.GetBytes(saltBytes);
        return Convert.ToBase64String(saltBytes);
    }
}
