namespace AuthService.Contracts.Requests;

/// <summary>Тело запроса для смены e-mail.</summary>
public sealed record ChangeEmailRequest(string NewEmail, string Password);