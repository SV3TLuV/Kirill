using Api.Common.Interfaces;
using Api.Models.CompletedWorks;
using Api.Models.Tasks;

namespace Api.Models.CompletedWorkTasks;

public sealed class CompletedWorkTaskViewModel : IMapWith<CompletedWorkTask>
{
    public CompletedWorkViewModel CompletedWork { get; set; } = null!;
    public TaskViewModel Task { get; set; } = null!;
}