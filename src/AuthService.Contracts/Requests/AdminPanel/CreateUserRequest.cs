namespace AuthService.Contracts.Requests.AdminPanel;

/// <summary>
///     Создание пользователя администратором.
/// </summary>
public sealed record CreateUserRequest(
    string Email,
    string Password,
    string FullName,
    string[] Roles,
    string[] Permissions,
    string? Description = null);