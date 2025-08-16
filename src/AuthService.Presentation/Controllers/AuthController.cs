using AuthService.Application.Commands.Auth.Commands;
using AuthService.Application.Commands.Auth.Handlers;
using AuthService.Contracts.Responses;
using CSharpFunctionalExtensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SharedKernel;

namespace AuthService.Presentation.Controllers;

[ApiController]
[Route("api/v1/auth")]
public sealed class AuthController : ControllerBase
{
    [HttpPost("login")]
    [AllowAnonymous]
    public async Task<IActionResult> Login(
        [FromBody] LoginRequest request,
        [FromServices] LoginHandler handler,
        [FromServices] ILogger<AuthController> logger,
        CancellationToken ct)
    {
        LoginCommand command = new(request.Email, request.Password);
        Result<TokensResponse, ErrorList> result = await handler.Handle(command, ct);
        return result.IsFailure ? result.Error.ToResponse() : Ok(result.Value);
    }
}