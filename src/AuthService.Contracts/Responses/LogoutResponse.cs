namespace AuthService.Contracts.Responses;

public sealed record LogoutResponse(
    bool Success,
    string Scope,
    DateTimeOffset LoggedOutAt
);