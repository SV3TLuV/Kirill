using Api.Common.Interfaces;

namespace Api.Models.Courses;

public sealed class CourseViewModel : IMapWith<Course>
{
    public int Id { get; set; }
}