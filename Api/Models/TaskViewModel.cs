using Api.Common.Interfaces;
using Task = Api.Entities.Task;

namespace Api.Models;

public sealed class TaskViewModel : IMapWith<Task>
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public string Description { get; set; } = null!;
}