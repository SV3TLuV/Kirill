using AutoMapper;

namespace Api.Common.Interfaces;

public interface IMapWith<T>
{
    void Map(Profile profile)
    {
        profile.CreateMap(typeof(T), GetType())
            .ReverseMap();
    }
}