namespace AuthService.Contracts.Requests;

/// <summary>Тело запроса для удаления аккаунта.</summary>
public sealed record DeleteProfileRequest(string Password);