using Api.Common.Interfaces;
using Api.Entities;

namespace Api.Models;

public sealed class GroupViewModel : IMapWith<Group>
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int Year { get; set; }

    public CourseViewModel Course { get; set; } = null!;

    public SemesterViewModel Semester { get; set; } = null!;

    public ICollection<DisciplineViewModel> Disciplines { get; set; } = null!;
}