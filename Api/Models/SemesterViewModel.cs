using Api.Common.Interfaces;
using Api.Entities;

namespace Api.Models;

public sealed class SemesterViewModel : IMapWith<Semester>
{
    public int Id { get; set; }
}