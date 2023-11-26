using System;
using System.Collections.Generic;

namespace Api.Entities;

public partial class Work
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int WorkTypeId { get; set; }

    public virtual ICollection<CompletedWork> CompletedWorks { get; set; } = new List<CompletedWork>();

    public virtual ICollection<GroupWork> GroupWorks { get; set; } = new List<GroupWork>();

    public virtual ICollection<Task> Tasks { get; set; } = new List<Task>();

    public virtual WorkMark? WorkMark { get; set; }

    public virtual WorkType WorkType { get; set; } = null!;
}
