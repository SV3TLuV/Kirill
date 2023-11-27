using Api.Common.Interfaces;
using Api.Models.Groups;
using Api.Models.Teachers;

namespace Api.Models.TeacherGroups;

public sealed class TeacherGroupViewModel : IMapWith<TeacherGroup>
{
    public TeacherViewModel Teacher { get; set; } = null!;
    public GroupViewModel Group { get; set; } = null!;
}