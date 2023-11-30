namespace Api.Models.Users.Commands;

public sealed class RefreshCommand
{
    public required string RefreshToken { get; set; }
    public required string AccessToken { get; set; }
}