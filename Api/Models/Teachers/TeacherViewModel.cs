using Api.Common.Interfaces;
using Api.Models.Users;

namespace Api.Models.Teachers;

public sealed class TeacherViewModel : IMapWith<Teacher>
{
    public int Id { get; set; }

    public UserViewModel User { get; set; } = null!;
}