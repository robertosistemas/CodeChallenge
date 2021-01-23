using AutoMapper;
using CodeChallenge.Application.DataTransferObjects;
using CodeChallenge.Domain.Models;

namespace CodeChallenge.Application.Mappings
{
    public class PagedProfile : Profile
    {
        public PagedProfile()
        {
            CreateMap<PagedModel, Paged>();
            CreateMap<Paged, PagedModel>();
        }
    }
}
