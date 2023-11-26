﻿using System;
using System.Collections.Generic;

namespace Api.Entities;

public partial class Semester
{
    public int Id { get; set; }

    public virtual ICollection<GroupWork> GroupWorks { get; set; } = new List<GroupWork>();

    public virtual ICollection<Group> Groups { get; set; } = new List<Group>();
}
