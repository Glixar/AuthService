namespace AuthService.Contracts.Requests.AdminPanel;

/// <summary>
///     Мягкое удаление пользователя по идентификатору.
/// </summary>
public sealed record DeleteUserByIdRequest(
    Guid Id);