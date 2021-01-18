using AutoMapper;
using CodeChallenge.Application.DataTransferObjects;
using CodeChallenge.Domain.Models;

namespace CodeChallenge.Application.Mappings
{
    public class PagedProfile : Profile
    {
        public PagedProfile()
        {
            CreateMap<Paged, PagedDto>();
            CreateMap<PagedDto, Paged>();
        }
    }
}
