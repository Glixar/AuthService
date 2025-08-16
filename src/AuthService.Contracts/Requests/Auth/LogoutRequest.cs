namespace AuthService.Contracts.Requests.Auth;

/// <summary>Выход.</summary>
public sealed record LogoutRequest(
    Guid RefreshToken,
    bool AllDevices);