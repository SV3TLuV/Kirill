using Api.Models.Courses;
using Api.Models.Disciplines;
using Api.Models.Groups;
using Api.Models.Semesters;
using Api.Models.Works;

namespace Api.Models.GroupWorks;

public class GroupWork
{
    public int Id { get; set; }

    public int GroupId { get; set; }

    public int WorkId { get; set; }

    public int DisciplineId { get; set; }

    public int CourseId { get; set; }

    public int SemesterId { get; set; }

    public virtual Course Course { get; set; } = null!;

    public virtual Discipline Discipline { get; set; } = null!;

    public virtual Group Group { get; set; } = null!;

    public virtual Semester Semester { get; set; } = null!;

    public virtual Work Work { get; set; } = null!;
}