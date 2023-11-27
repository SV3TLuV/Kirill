using Api.Common.Interfaces;
using Api.Entities;

namespace Api.Models;

public sealed class CompletedWorkViewModel : IMapWith<CompletedWork>
{
    public int Id { get; set; }

    public int Percentage { get; set; }

    public MarkViewModel Mark { get; set; } = null!;

    public StudentViewModel Student { get; set; } = null!;

    public WorkViewModel Work { get; set; } = null!;

    public ICollection<TaskViewModel> Tasks { get; set; } = null!;
}