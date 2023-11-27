using Api.Common.Interfaces;
using Api.Entities;

namespace Api.Models;

public sealed class CourseViewModel : IMapWith<Course>
{
    public int Id { get; set; }
}