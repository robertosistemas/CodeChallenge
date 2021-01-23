using AutoMapper;
using CodeChallenge.Application.DataTransferObjects;
using CodeChallenge.Domain.Models;

namespace CodeChallenge.Application.Mappings
{
    public class CoordinatesProfile : Profile
    {
        public CoordinatesProfile()
        {
            CreateMap<CoordinatesModel, Coordinates>();
            CreateMap<Coordinates, CoordinatesModel>();
        }
    }
}
