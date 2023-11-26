using Api.Common.Interfaces;
using Api.Entities;

namespace Api.Models;

public sealed class WorkViewModel : IMapWith<Work>
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public WorkTypeViewModel WorkType { get; set; } = null!;

    public ICollection<TaskViewModel> Tasks { get; set; } = null!;

    public ICollection<WorkMarkViewModel> WorkMarks { get; set; } = null!;
}