using System.Security.Claims;
using Api.Common.Interfaces;
using Api.Context;
using Api.Models.Sessions;
using Api.Models.Users;
using Api.Models.Users.Commands;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api.Controllers;

public sealed class UserController : BaseController
{
    [HttpPost("{id:int}/change_password")]
    public async Task<ActionResult> Post(
        int id,
        [FromBody] ChangePasswordCommand command,
        [FromServices] ApiDbContext context)
    {
        var user = await context.Users
            .AsNoTracking()
            .Include(e => e.Role)
            .FirstOrDefaultAsync(e => e.Id == id);

        if (user is null)
        {
            return NotFound();
        }

        if (command.Password != command.ConfirmPassword)
        {
            return BadRequest();
        }

        user.Password = command.Password;

        await context.SaveChangesAsync();
        return Ok();
    }

    [HttpPost("/login")]
    public async Task<ActionResult<AuthorizationResultViewModel>> Login(
        [FromBody] LoginCommand command,
        [FromServices] IMapper mapper,
        [FromServices] ApiDbContext context,
        [FromServices] ITokenService tokenService)
    {
        var user = await context.Set<User>()
            .AsNoTracking()
            .Include(e => e.Role)
            .FirstOrDefaultAsync(e => e.Login == command.Login);

        if (user is null)
            return BadRequest("Incorrect login or password.");

        var session = new Session
        {
            Id = Guid.NewGuid(),
            RefreshToken = tokenService.GenerateRefreshToken(),
            UserId = user.Id
        };

        var userViewModel = mapper.Map<UserViewModel>(user);
        var accessToken = tokenService.GenerateAccessToken(user, session.Id);

        return Ok(new AuthorizationResultViewModel
        {
            AccessToken = accessToken,
            RefreshToken = session.RefreshToken,
            User = userViewModel
        });
    }

    [HttpPost("/refresh")]
    public async Task<ActionResult<AuthorizationResultViewModel>> Refresh(
        [FromBody] RefreshCommand command,
        [FromServices] IMapper mapper,
        [FromServices] ApiDbContext context,
        [FromServices] ITokenService tokenService)
    {
        var principal = tokenService.GetPrincipalFromExpiredToken(command.AccessToken);
        var sidClaim = principal.FindFirst(ClaimTypes.Sid);

        if (sidClaim is null || !Guid.TryParse(sidClaim.Value, out var sessionId))
           return BadRequest("Invalid AccessToken.");

        var session = await context.Set<Session>()
            .Include(e => e.User)
            .ThenInclude(e => e.Role)
            .FirstOrDefaultAsync(e => e.Id == sessionId);

        if (session is null)
            return NotFound($"Sessions with id: {sessionId}");

        if (session.RefreshToken != command.RefreshToken)
            return NotFound("Invalid RefreshToken");

        session.RefreshToken = tokenService.GenerateRefreshToken();

        context.Update(session);
        await context.SaveChangesAsync();

        var userViewModel = mapper.Map<UserViewModel>(session.User);
        var accessToken = tokenService.GenerateAccessToken(session.User, session.Id);

        return Ok(new AuthorizationResultViewModel
        {
            AccessToken = accessToken,
            RefreshToken = session.RefreshToken,
            User = userViewModel
        });
    }
}