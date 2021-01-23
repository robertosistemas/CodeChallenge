using AutoMapper;
using CodeChallenge.Application.DataTransferObjects;
using CodeChallenge.Domain.Models;

namespace CodeChallenge.Application.Mappings
{
    public class NameProfile : Profile
    {
        public NameProfile()
        {
            CreateMap<NameModel, Name>();
            CreateMap<Name, NameModel>();
        }
    }
}
