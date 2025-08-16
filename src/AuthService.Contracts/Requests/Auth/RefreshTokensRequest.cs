namespace AuthService.Contracts.Requests.Auth;

/// <summary>Обновление токенов.</summary>
public sealed record RefreshTokensRequest(Guid RefreshToken);