using AuthService.Application.Abstractions;
using AuthService.Application.Commands.Auth.Commands;
using AuthService.Contracts.Responses;
using CSharpFunctionalExtensions;
using Microsoft.Extensions.Logging;
using SharedKernel;

namespace AuthService.Application.Commands.Auth.Handlers;

public sealed class RegisterHandler : ICommandHandler<TokensResponse, RegisterCommand>
{
    private readonly ILogger<RegisterHandler> _logger;

    public RegisterHandler(
        ILogger<RegisterHandler> logger)
    {
        _logger = logger;
    }

    public async Task<Result<TokensResponse, ErrorList>> Handle(RegisterCommand command, CancellationToken ct)
    {
        throw new NotImplementedException();
    }
}