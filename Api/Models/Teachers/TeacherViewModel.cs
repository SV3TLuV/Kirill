using Api.Common.Interfaces;
using Api.Entities;

namespace Api.Models;

public sealed class TeacherViewModel : IMapWith<Teacher>
{
    public int Id { get; set; }

    public UserViewModel User { get; set; } = null!;

    public ICollection<GroupViewModel> Groups { get; set; } = null!;
}