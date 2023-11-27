using Api.Common.Interfaces;

namespace Api.Models.WorkTypes;

public sealed class WorkTypeViewModel : IMapWith<WorkType>
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;
}