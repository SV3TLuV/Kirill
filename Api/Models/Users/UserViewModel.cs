using Api.Common.Interfaces;
using Api.Entities;

namespace Api.Models;

public sealed class UserViewModel : IMapWith<User>
{
    public int Id { get; set; }

    public string Login { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string Surname { get; set; } = null!;

    public string Patronymic { get; set; } = null!;
}