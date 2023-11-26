﻿namespace Api.Entities;

public class Course
{
    public int Id { get; set; }

    public virtual ICollection<GroupWork> GroupWorks { get; set; } = new List<GroupWork>();

    public virtual ICollection<Group> Groups { get; set; } = new List<Group>();
}