namespace Api.Models.Users.Commands;

public sealed class ChangePasswordCommand
{
    public string Password { get; set; } = null!;
    public string ConfirmPassword { get; set; } = null!;
}