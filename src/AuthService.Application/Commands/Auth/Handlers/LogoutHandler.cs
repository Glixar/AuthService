using AuthService.Application.Abstractions;
using AuthService.Application.Commands.Auth.Commands;
using AuthService.Contracts.Responses;
using CSharpFunctionalExtensions;
using Microsoft.Extensions.Logging;
using SharedKernel;

namespace AuthService.Application.Commands.Auth.Handlers;

public sealed class LogoutHandler : ICommandHandler<LogoutResponse, LogoutCommand>
{
    private readonly ILogger<LogoutHandler> _logger;

    public LogoutHandler(
        ILogger<LogoutHandler> logger)
    {
        _logger = logger;
    }

    public async Task<Result<LogoutResponse, ErrorList>> Handle(LogoutCommand command, CancellationToken ct)
    {
        throw  new NotImplementedException();
    }
}