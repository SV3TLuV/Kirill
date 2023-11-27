using Api.Context;
using Api.Models.Users.Commands;
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
    public async Task<ActionResult> Login(
        [FromServices] ApiDbContext context)
    {
        throw new NotImplementedException();
    }

    [HttpPost("/refresh")]
    public async Task<ActionResult> Refresh(
        [FromServices] ApiDbContext context)
    {
        throw new NotImplementedException();
    }
}