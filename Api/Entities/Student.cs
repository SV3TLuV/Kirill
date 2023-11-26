using System;
using System.Collections.Generic;

namespace Api.Entities;

public partial class Student
{
    public int Id { get; set; }

    public bool IsRetired { get; set; }

    public int UserId { get; set; }

    public int GroupId { get; set; }

    public virtual ICollection<CompletedWork> CompletedWorks { get; set; } = new List<CompletedWork>();

    public virtual Group Group { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
