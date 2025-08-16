using AuthService.Application.Abstractions;
using AuthService.Application.Commands.Auth.Commands;
using AuthService.Contracts.Responses;
using AuthService.Domain;
using CSharpFunctionalExtensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using SharedKernel;

namespace AuthService.Application.Commands.Auth.Handlers;

public sealed class CheckEmailHandler : ICommandHandler<CheckEmailResponse, CheckEmailCommand>
{
    private readonly ILogger<CheckEmailHandler> _logger;

    public CheckEmailHandler(UserManager<User> userManager, ILogger<CheckEmailHandler> logger)
    {
        _logger = logger;
    }

    public async Task<Result<CheckEmailResponse, ErrorList>> Handle(CheckEmailCommand command, CancellationToken ct)
    {
        throw new NotImplementedException();
    }
}