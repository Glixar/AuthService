using AuthService.Application.Abstractions;
using AuthService.Application.Commands.Auth.Commands;
using AuthService.Contracts.Responses;
using CSharpFunctionalExtensions;
using Microsoft.Extensions.Logging;
using SharedKernel;

namespace AuthService.Application.Commands.Auth.Handlers;

public sealed class RefreshTokensHandler : ICommandHandler<TokensResponse, RefreshTokensCommand>
{
    private readonly ILogger<RefreshTokensHandler> _logger;

    public RefreshTokensHandler(ILogger<RefreshTokensHandler> logger)
    {
        _logger = logger;
    }

    public async Task<Result<TokensResponse, ErrorList>> Handle(RefreshTokensCommand command, CancellationToken ct)
    {
        throw new NotImplementedException();
    }
}