using Api.Common.Interfaces;
using Api.Models.Groups;
using Api.Models.Users;

namespace Api.Models.Students;

public sealed class StudentViewModel : IMapWith<Student>
{
    public int Id { get; set; }

    public bool IsRetired { get; set; }

    public UserViewModel User { get; set; } = null!;

    public GroupViewModel Group { get; set; } = null!;
}