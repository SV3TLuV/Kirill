using Api.Common.Interfaces;
using Api.Models.Marks;

namespace Api.Models.WorkMarks;

public sealed class WorkMarkViewModel : IMapWith<WorkMark>
{
    public MarkViewModel Mark { get; set; } = null!;

    public int TaskCount { get; set; }
}