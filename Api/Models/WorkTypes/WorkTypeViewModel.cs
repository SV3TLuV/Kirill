using Api.Common.Interfaces;
using Api.Entities;

namespace Api.Models;

public sealed class WorkTypeViewModel : IMapWith<WorkType>
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;
}