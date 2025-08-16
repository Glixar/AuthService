namespace AuthService.Contracts.Requests.Auth;

/// <summary>Проверка e-mail.</summary>
public sealed record CheckEmailRequest(
    string Email);