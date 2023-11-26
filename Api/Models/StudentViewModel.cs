using Api.Common.Interfaces;
using Api.Entities;

namespace Api.Models;

public sealed class StudentViewModel : IMapWith<Student>
{
    public int Id { get; set; }

    public bool IsRetired { get; set; }

    public UserViewModel User { get; set; } = null!;

    public GroupViewModel Group { get; set; } = null!;
}