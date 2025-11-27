namespace AuthService.Contracts.Requests.AdminPanel;

/// <summary>
///     Получение пользователя по e-mail.
/// </summary>
public sealed record GetUserByEmailRequest(
    string Email,
    bool IncludeDeleted = false);