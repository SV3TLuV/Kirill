using System;
using System.Collections.Generic;

namespace Api.Entities;

public partial class Teacher
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public virtual User User { get; set; } = null!;

    public virtual ICollection<Group> Groups { get; set; } = new List<Group>();
}
