using Api.Common.Interfaces;

namespace Api.Models.WorkTypes.Commands;

public sealed class WorkTypeCommand : IMapWith<WorkType>
{
    public required string Name { get; set; }
}