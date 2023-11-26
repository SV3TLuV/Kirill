using System;
using System.Collections.Generic;

namespace Api.Entities;

public partial class WorkMark
{
    public int WorkId { get; set; }

    public int MarkId { get; set; }

    public int TaskCount { get; set; }

    public virtual Mark Mark { get; set; } = null!;

    public virtual Work Work { get; set; } = null!;
}
