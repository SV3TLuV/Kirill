using Api.Common.Interfaces;
using Api.Entities;

namespace Api.Models;

public sealed class DisciplineViewModel : IMapWith<Discipline>
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;
}