using Api.Common.Interfaces;
using Api.Models.WorkMarks;

namespace Api.Models.Works.Commands;

public sealed class CreateWorkCommand : IMapWith<Work>
{
    public string Name { get; set; } = null!;
    
    public int WorkTypeId { get; set; }
    
    public ICollection<WorkMarkViewModel>? WorkMarks { get; set; }
}