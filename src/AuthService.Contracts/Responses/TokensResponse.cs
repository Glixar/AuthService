namespace AuthService.Contracts.Responses;

public sealed record TokensResponse(
    string AccessToken,
    DateTimeOffset AccessExpiresAt,
    Guid RefreshToken,
    DateTimeOffset RefreshExpiresAt
);