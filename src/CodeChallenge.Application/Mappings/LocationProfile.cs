using AutoMapper;
using CodeChallenge.Application.DataTransferObjects;
using CodeChallenge.Domain.Models;

namespace CodeChallenge.Application.Mappings
{
    public class LocationProfile : Profile
    {
        public LocationProfile()
        {
            CreateMap<LocationModel, Location>();
            CreateMap<Location, LocationModel>();
        }
    }
}
