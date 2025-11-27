namespace AuthService.Contracts.Requests.AdminPanel;

/// <summary>
///     Восстановление ранее удалённого пользователя.
/// </summary>
public sealed record RestoreUserRequest(
    Guid Id);