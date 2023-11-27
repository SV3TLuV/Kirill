using Api.Common.Interfaces;
using Api.Models.Courses;
using Api.Models.Disciplines;
using Api.Models.Semesters;
using AutoMapper;

namespace Api.Models.Groups;

public sealed class GroupViewModel : IMapWith<Group>
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int Year { get; set; }

    public CourseViewModel Course { get; set; } = null!;

    public SemesterViewModel Semester { get; set; } = null!;

    public ICollection<DisciplineViewModel> Disciplines { get; set; } = null!;

    public void Map(Profile profile)
    {
        profile.CreateMap<Group, GroupViewModel>()
            .ForMember(e => e.Disciplines, expression =>
                expression.MapFrom(e => e.GroupDisciplines
                    .Select(e => e.Discipline)));
    }
}