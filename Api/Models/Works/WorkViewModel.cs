using Api.Common.Interfaces;
using Api.Models.Tasks;
using Api.Models.WorkMarks;
using Api.Models.WorkTypes;

namespace Api.Models.Works;

public sealed class WorkViewModel : IMapWith<Work>
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public WorkTypeViewModel WorkType { get; set; } = null!;

    public ICollection<TaskViewModel> Tasks { get; set; } = null!;

    public ICollection<WorkMarkViewModel> WorkMarks { get; set; } = null!;
}