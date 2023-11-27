using Api.Common.Interfaces;

namespace Api.Models.Tasks.Commands;

public sealed class TaskCommand : IMapWith<Task>
{
    public int WorkId { get; set; }

    public string Title { get; set; } = null!;

    public string Description { get; set; } = null!;
}