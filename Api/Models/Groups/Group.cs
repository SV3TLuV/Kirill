using Api.Models.Courses;
using Api.Models.Disciplines;
using Api.Models.GroupDisciplines;
using Api.Models.GroupWorks;
using Api.Models.Semesters;
using Api.Models.Students;
using Api.Models.TeacherGroups;
using Api.Models.Teachers;

namespace Api.Models.Groups;

public class Group
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int Year { get; set; }

    public int CourseId { get; set; }

    public int SemesterId { get; set; }

    public virtual Course Course { get; set; } = null!;

    public virtual ICollection<GroupWork> GroupWorks { get; set; } = new List<GroupWork>();

    public virtual Semester Semester { get; set; } = null!;

    public virtual ICollection<Student> Students { get; set; } = new List<Student>();

    public virtual ICollection<GroupDiscipline> GroupDisciplines { get; set; } = new List<GroupDiscipline>();

    public virtual ICollection<TeacherGroup> TeacherGroups { get; set; } = new List<TeacherGroup>();
}