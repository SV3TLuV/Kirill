using Api.Common.Interfaces;

namespace Api.Models.Disciplines;

public sealed class DisciplineViewModel : IMapWith<Discipline>
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;
}