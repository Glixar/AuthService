namespace AuthService.Contracts.Requests.AdminPanel;

/// <summary>
///     Получение списка пользователей с пагинацией.
/// </summary>
public sealed record GetAllUsersRequest(
    int Offset = 0,
    int Limit = 50,
    bool IncludeDeleted = false);