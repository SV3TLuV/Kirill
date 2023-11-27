using Api.Common.Interfaces;

namespace Api.Models.Semesters;

public sealed class SemesterViewModel : IMapWith<Semester>
{
    public int Id { get; set; }
}