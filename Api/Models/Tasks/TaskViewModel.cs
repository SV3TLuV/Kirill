using Api.Common.Interfaces;

namespace Api.Models.Tasks;

public sealed class TaskViewModel : IMapWith<Task>
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public string Description { get; set; } = null!;
}