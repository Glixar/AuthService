namespace AuthService.Contracts.Requests.AdminPanel;

/// <summary>
///     Получение пользователя по идентификатору.
/// </summary>
public sealed record GetUserByIdRequest(
    Guid Id,
    bool IncludeDeleted = false);