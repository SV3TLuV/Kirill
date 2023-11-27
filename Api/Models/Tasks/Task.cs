using Api.Models.CompletedWorkTasks;
using Api.Models.Works;

namespace Api.Models.Tasks;

public class Task
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public string Description { get; set; } = null!;

    public int WorkId { get; set; }

    public virtual Work Work { get; set; } = null!;

    public virtual ICollection<CompletedWorkTask> CompletedWorkTasks { get; set; } = new List<CompletedWorkTask>();
}