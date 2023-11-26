using System;
using System.Collections.Generic;

namespace Api.Entities;

public partial class WorkType
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Work> Works { get; set; } = new List<Work>();
}
