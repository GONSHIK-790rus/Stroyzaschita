﻿namespace Stroyzaschita.Shared.DTOs.Auth;

public class LoginResponse {
    public string Token { get; set; } = default!;
    public string Login { get; set; } = default!;
}
