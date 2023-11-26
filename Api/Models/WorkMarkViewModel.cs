using Api.Common.Interfaces;
using Api.Entities;

namespace Api.Models;

public sealed class WorkMarkViewModel : IMapWith<WorkMark>
{
    public MarkViewModel Mark { get; set; } = null!;

    public int TaskCount { get; set; }
}