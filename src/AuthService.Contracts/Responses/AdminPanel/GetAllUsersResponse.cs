namespace AuthService.Contracts.Responses.AdminPanel;

/// <summary>
///     Пагинированный ответ со списком пользователей.
/// </summary>
public sealed record GetAllUsersResponse(
    IReadOnlyList<UserAdminItemResponse> Items,
    int Total,
    int Offset,
    int Limit
);