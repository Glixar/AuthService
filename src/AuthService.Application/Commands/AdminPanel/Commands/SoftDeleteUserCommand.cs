using AuthService.Application.Abstractions;

namespace AuthService.Application.Commands.AdminPanel.Commands;

public sealed record SoftDeleteUserCommand(Guid Id) : ICommand;