using Api.Models.CompletedWorks;
using Api.Models.WorkMarks;

namespace Api.Models.Marks;

public class Mark
{
    public int Id { get; set; }

    public int Value { get; set; }

    public virtual ICollection<CompletedWork> CompletedWorks { get; set; } = new List<CompletedWork>();

    public virtual ICollection<WorkMark> WorkMarks { get; set; } = new List<WorkMark>();
}