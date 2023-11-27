using Api.Models.GroupDisciplines;
using Api.Models.GroupWorks;

namespace Api.Models.Disciplines;

public class Discipline
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<GroupWork> GroupWorks { get; set; } = new List<GroupWork>();

    public virtual ICollection<GroupDiscipline> GroupDisciplines { get; set; } = new List<GroupDiscipline>();
}