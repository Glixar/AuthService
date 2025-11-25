namespace AuthService.Contracts.Responses;

public sealed record MyProfileResponse(string FullName, string Email, string Description);