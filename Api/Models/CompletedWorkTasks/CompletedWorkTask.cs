using Api.Models.CompletedWorks;
using Task = Api.Models.Tasks.Task;

namespace Api.Models.CompletedWorkTasks;

public class CompletedWorkTask
{
    public int CompletedWorkId { get; set; }

    public CompletedWork CompletedWork { get; set; } = null!;

    public int TaskId { get; set; }

    public Task Task { get; set; } = null!;
}