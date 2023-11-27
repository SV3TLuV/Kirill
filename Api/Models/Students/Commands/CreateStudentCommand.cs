﻿using Api.Common.Interfaces;
using AutoMapper;

namespace Api.Models.Students.Commands;

public sealed class CreateStudentCommand : IMapWith<Student>
{
    public int GroupId { get; set; }

    public string Login { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string Surname { get; set; } = null!;

    public string Patronymic { get; set; } = null!;

    public void Map(Profile profile)
    {
        profile.CreateMap<Student, CreateStudentCommand>()
            .ForMember(e => e.Login, expression =>
                expression.MapFrom(e => e.User.Login))
            .ForMember(e => e.Password, expression =>
                expression.MapFrom(e => e.User.Password))
            .ForMember(e => e.Name, expression =>
                expression.MapFrom(e => e.User.Name))
            .ForMember(e => e.Surname, expression =>
                expression.MapFrom(e => e.User.Surname))
            .ForMember(e => e.Patronymic, expression =>
                expression.MapFrom(e => e.User.Patronymic))
            .ReverseMap();
    }
}