using Api.Common.Interfaces;

namespace Api.Models.Marks;

public sealed class MarkViewModel : IMapWith<Mark>
{
    public int Id { get; set; }

    public int Value { get; set; }
}