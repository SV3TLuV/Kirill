using Api.Common.Interfaces;

namespace Api.Models.Roles;

public sealed class RoleViewModel : IMapWith<Role>
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
}