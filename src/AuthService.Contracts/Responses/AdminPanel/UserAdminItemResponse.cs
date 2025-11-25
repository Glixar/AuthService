namespace AuthService.Contracts.Responses.AdminPanel;

/// <summary>
///     Элемент выдачи пользователя для админ-панели.
/// </summary>
public sealed record UserAdminItemResponse(
    Guid Id,
    string? Email,
    string? FullName,
    string? Description,
    bool IsDeleted,
    DateTime? DeletedAtUtc,
    bool EmailConfirmed,
    bool LockoutEnabled,
    DateTimeOffset? LockoutEnd
);