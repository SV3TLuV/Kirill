using Api.Models.CompletedWorks;
using Api.Models.GroupWorks;
using Api.Models.WorkMarks;
using Api.Models.WorkTypes;
using Task = Api.Models.Tasks.Task;

namespace Api.Models.Works;

public class Work
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int WorkTypeId { get; set; }

    public virtual ICollection<CompletedWork> CompletedWorks { get; set; } = new List<CompletedWork>();

    public virtual ICollection<GroupWork> GroupWorks { get; set; } = new List<GroupWork>();

    public virtual ICollection<Task>? Tasks { get; set; } = new List<Task>();

    public virtual ICollection<WorkMark> WorkMarks { get; set; } = new List<WorkMark>();

    public virtual WorkType WorkType { get; set; } = null!;
}