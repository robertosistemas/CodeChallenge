using AutoMapper;
using CodeChallenge.Application.DataTransferObjects;
using CodeChallenge.Domain.Models;

namespace CodeChallenge.Application.Mappings
{
    public class TimezoneProfile : Profile
    {
        public TimezoneProfile()
        {
            CreateMap<TimezoneModel, Timezone>();
            CreateMap<Timezone, TimezoneModel>();
        }
    }
}
