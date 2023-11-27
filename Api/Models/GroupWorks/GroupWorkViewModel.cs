using Api.Common.Interfaces;
using Api.Entities;

namespace Api.Models;

public sealed class GroupWorkViewModel : IMapWith<GroupWork>
{
    public int Id { get; set; }

    public CourseViewModel Course { get; set; } = null!;

    public DisciplineViewModel Discipline { get; set; } = null!;

    public GroupViewModel Group { get; set; } = null!;

    public SemesterViewModel Semester { get; set; } = null!;

    public WorkViewModel Work { get; set; } = null!;
}