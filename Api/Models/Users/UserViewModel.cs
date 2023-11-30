using Api.Common.Interfaces;
using Api.Models.Roles;

namespace Api.Models.Users;

public sealed class UserViewModel : IMapWith<User>
{
    public int Id { get; set; }

    public string Login { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string Surname { get; set; } = null!;

    public string Patronymic { get; set; } = null!;

    public RoleViewModel Role { get; set; } = null!;
}