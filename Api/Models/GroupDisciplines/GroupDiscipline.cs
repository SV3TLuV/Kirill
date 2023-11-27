using Api.Models.Disciplines;
using Api.Models.Groups;

namespace Api.Models.GroupDisciplines;

public class GroupDiscipline
{
    public int GroupId { get; set; }

    public Group Group { get; set; } = null!;

    public int DisciplineId { get; set; }

    public Discipline Discipline { get; set; } = null!;
}