using System;
using System.Collections.Generic;

namespace Api.Entities;

public partial class CompletedWork
{
    public int Id { get; set; }

    public int Percentage { get; set; }

    public int MarkId { get; set; }

    public int WorkId { get; set; }

    public int StudentId { get; set; }

    public virtual Mark Mark { get; set; } = null!;

    public virtual Student Student { get; set; } = null!;

    public virtual Work Work { get; set; } = null!;

    public virtual ICollection<Task> Tasks { get; set; } = new List<Task>();
}
