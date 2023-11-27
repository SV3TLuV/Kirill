using Api.Common.Interfaces;

namespace Api.Models.Disciplines.Commands;

public sealed class DisciplineCommand : IMapWith<Discipline>
{
    public required string Name { get; set; }
}