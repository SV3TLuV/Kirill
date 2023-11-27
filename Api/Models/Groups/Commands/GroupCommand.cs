using Api.Common.Interfaces;

namespace Api.Models.Groups.Commands;

public sealed class GroupCommand : IMapWith<Group>
{
    public string Name { get; set; } = null!;

    public int Year { get; set; }

    public int CourseId { get; set; }

    public int SemesterId { get; set; }

    public ICollection<int>? DisciplineIds { get; set; }
}