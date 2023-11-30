namespace Api.Models.Users.Commands;

public sealed class LoginCommand
{
    public required string Login { get; set; }
    public required string Password { get; set; }
}