using System;
using System.Collections.Generic;

namespace Api.Entities;

public partial class Group
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

    public virtual ICollection<Discipline> Disciplines { get; set; } = new List<Discipline>();

    public virtual ICollection<Teacher> Teachers { get; set; } = new List<Teacher>();
}
