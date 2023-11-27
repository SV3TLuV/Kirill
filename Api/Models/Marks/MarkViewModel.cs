using Api.Common.Interfaces;
using Api.Entities;

namespace Api.Models;

public sealed class MarkViewModel : IMapWith<Mark>
{
    public int Id { get; set; }

    public int Value { get; set; }
}