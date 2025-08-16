namespace AuthService.Contracts.Requests.Auth;

/// <summary>Регистрация.</summary>
public sealed record RegisterRequest(
    string Email,
    string Password,
    string FullName);