using AutoMapper;
using CodeChallenge.Application.DataTransferObjects;
using CodeChallenge.Domain.Models;

namespace CodeChallenge.Application.Mappings
{
    public class RegisteredProfile : Profile
    {
        public RegisteredProfile()
        {
            CreateMap<RegisteredModel, Registered>();
            CreateMap<Registered, RegisteredModel>();
        }
    }
}
