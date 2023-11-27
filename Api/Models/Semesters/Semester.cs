using Api.Models.Groups;
using Api.Models.GroupWorks;

namespace Api.Models.Semesters;

public class Semester
{
    public int Id { get; set; }

    public virtual ICollection<GroupWork> GroupWorks { get; set; } = new List<GroupWork>();

    public virtual ICollection<Group> Groups { get; set; } = new List<Group>();
}