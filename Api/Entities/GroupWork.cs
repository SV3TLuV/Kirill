using System;
using System.Collections.Generic;

namespace Api.Entities;

public partial class GroupWork
{
    public int GroupId { get; set; }

    public int WorkId { get; set; }

    public int DisciplineId { get; set; }

    public int CourseId { get; set; }

    public int SemesterId { get; set; }

    public int Id { get; set; }

    public virtual Course Course { get; set; } = null!;

    public virtual Discipline Discipline { get; set; } = null!;

    public virtual Group Group { get; set; } = null!;

    public virtual Semester Semester { get; set; } = null!;

    public virtual Work Work { get; set; } = null!;
}
