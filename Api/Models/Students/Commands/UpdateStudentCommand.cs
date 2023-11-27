using Api.Common.Interfaces;
using AutoMapper;

namespace Api.Models.Students.Commands;

public sealed class UpdateStudentCommand : IMapWith<Student>
{
    public int GroupId { get; set; }

    public string Login { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string Surname { get; set; } = null!;

    public string Patronymic { get; set; } = null!;

    public bool IsRetired { get; set; }

    public void Map(Profile profile)
    {
        profile.CreateMap<Student, UpdateStudentCommand>()
            .ForMember(e => e.Login, expression =>
                expression.MapFrom(e => e.User.Login))
            .ForMember(e => e.Name, expression =>
                expression.MapFrom(e => e.User.Name))
            .ForMember(e => e.Surname, expression =>
                expression.MapFrom(e => e.User.Surname))
            .ForMember(e => e.Patronymic, expression =>
                expression.MapFrom(e => e.User.Patronymic))
            .ReverseMap();
    }
}