using AutoMapper;
using CodeChallenge.Application.DataTransferObjects;
using CodeChallenge.Domain.Models;

namespace CodeChallenge.Application.Mappings
{
    public class DobProfile : Profile
    {
        public DobProfile()
        {
            CreateMap<Dob, DobDto>();
            CreateMap<DobDto, Dob>();
        }
    }
}
