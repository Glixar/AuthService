namespace AuthService.Contracts.Responses;

public sealed record AdminUserResponse(
    Guid Id,
    string UserName,
    string Email,
    bool EmailConfirmed,
    bool IsDeleted,
    DateTime? DeletedAtUtc,
    string? Description,
    IReadOnlyList<string> Roles
);