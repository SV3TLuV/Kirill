using Api.Models.TeacherGroups;
using Api.Models.Users;

namespace Api.Models.Teachers;

public class Teacher
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public virtual User User { get; set; } = null!;

    public virtual ICollection<TeacherGroup> TeacherGroups { get; set; } = new List<TeacherGroup>();
}