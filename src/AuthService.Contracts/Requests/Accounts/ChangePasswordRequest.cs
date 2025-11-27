namespace AuthService.Contracts.Requests;

/// <summary>Тело запроса для смены пароля.</summary>
public sealed record ChangePasswordRequest(string OldPassword, string NewPassword);