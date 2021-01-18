using AutoMapper;
using CodeChallenge.Application.DataTransferObjects;
using CodeChallenge.Domain.Models;

namespace CodeChallenge.Application.Mappings
{
    public class TimezoneProfile : Profile
    {
        public TimezoneProfile()
        {
            CreateMap<Timezone, TimezoneDto>();
            CreateMap<TimezoneDto, Timezone>();
        }
    }
}
