using Api.Models.Users;

namespace Api.Models.Sessions;

public class Session
{
    public int UserId { get; set; }

    public Guid Id { get; set; }

    public string RefreshToken { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
