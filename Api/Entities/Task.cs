namespace Api.Entities;

public class Task
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public string Description { get; set; } = null!;

    public int WorkId { get; set; }

    public virtual Work Work { get; set; } = null!;

    public virtual ICollection<CompletedWork> CompletedWorks { get; set; } = new List<CompletedWork>();
}