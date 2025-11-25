namespace AuthService.Contracts.Responses.AdminPanel;

/// <summary>
///     Результат логического удаления (soft-delete) пользователя.
/// </summary>
public sealed record DeleteUserResponse(Guid Id);