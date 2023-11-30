using Api.Common.Interfaces;
using Api.Models.Marks;
using Api.Models.Students;
using Api.Models.Tasks;
using Api.Models.Works;
using AutoMapper;

namespace Api.Models.CompletedWorks;

public sealed class CompletedWorkViewModel : IMapWith<CompletedWork>
{
    public int Id { get; set; }

    public int Percentage { get; set; }

    public MarkViewModel? Mark { get; set; }

    public StudentViewModel Student { get; set; } = null!;

    public WorkViewModel Work { get; set; } = null!;

    public ICollection<TaskViewModel> Tasks { get; set; } = null!;

    public void Map(Profile profile)
    {
        profile.CreateMap<CompletedWork, CompletedWorkViewModel>()
            .ForMember(e => e.Tasks, expression =>
                expression.MapFrom(e => e.CompletedTasks
                    .Select(e => e.Task)));
    }
}