namespace AuthService.Contracts.Requests.AdminPanel;

/// <summary>
///     Обновление свойств пользователя администратором.
///     Любое поле, равное null, не изменяется.
/// </summary>
public sealed record UpdateUserRequest(
    Guid Id,
    string? Email = null,
    string? FullName = null,
    string? Description = null,
    bool? Lockout = null,
    string[]? Roles = null,
    string[]? Permissions = null);