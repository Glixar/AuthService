namespace AuthService.Contracts.Requests.Auth;

/// <summary>Вход.</summary>
public sealed record LoginRequest(
    string Email,
    string Password);