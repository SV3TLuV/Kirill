using Api.Common.Interfaces;
using Api.Models.Disciplines;
using Api.Models.Groups;

namespace Api.Models.GroupDisciplines;

public sealed class GroupDisciplineViewModel : IMapWith<GroupDiscipline>
{
    public GroupViewModel Group { get; set; } = null!;
    public DisciplineViewModel Discipline { get; set; } = null!;
}