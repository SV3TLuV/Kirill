using Api.Models.CompletedWorkTasks;
using Api.Models.Marks;
using Api.Models.Students;
using Api.Models.Works;

namespace Api.Models.CompletedWorks;

public class CompletedWork
{
    public int Id { get; set; }

    public int Percentage { get; set; }

    public int? MarkId { get; set; }

    public int WorkId { get; set; }

    public int StudentId { get; set; }

    public virtual Mark? Mark { get; set; } = null!;

    public virtual Student Student { get; set; } = null!;

    public virtual Work Work { get; set; } = null!;

    public virtual ICollection<CompletedWorkTask> CompletedTasks { get; set; } = new List<CompletedWorkTask>();
}