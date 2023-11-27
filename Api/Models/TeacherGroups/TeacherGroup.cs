using Api.Models.Groups;
using Api.Models.Teachers;

namespace Api.Models.TeacherGroups;

public class TeacherGroup
{
    public int TeacherId { get; set; }

    public Teacher Teacher { get; set; } = null!;

    public int GroupId { get; set; }

    public Group Group { get; set; } = null!;
}