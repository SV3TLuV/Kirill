using Api.Models.Groups;
using Api.Models.GroupWorks;

namespace Api.Models.Disciplines;

public class Discipline
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<GroupWork> GroupWorks { get; set; } = new List<GroupWork>();

    public virtual ICollection<Group> Groups { get; set; } = new List<Group>();
}