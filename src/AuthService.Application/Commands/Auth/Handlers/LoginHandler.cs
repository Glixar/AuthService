using AuthService.Application.Abstractions;
using AuthService.Application.Commands.Auth.Commands;
using AuthService.Contracts.Responses;
using CSharpFunctionalExtensions;
using Microsoft.Extensions.Logging;
using SharedKernel;

namespace AuthService.Application.Commands.Auth.Handlers;

public sealed class LoginHandler : ICommandHandler<TokensResponse, LoginCommand>
{
    private readonly ILogger<LoginHandler> _logger;

    public LoginHandler(ILogger<LoginHandler> logger)
    {
        _logger = logger;
    }

    public async Task<Result<TokensResponse, ErrorList>> Handle(LoginCommand command, CancellationToken ct)
    {
        throw new NotImplementedException();
    }
}