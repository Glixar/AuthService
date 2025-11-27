namespace AuthService.Contracts.Requests;

/// <summary>Тело запроса для обновления профиля.</summary>
public sealed record UpdateProfileRequest(string? FullName, string? Description);