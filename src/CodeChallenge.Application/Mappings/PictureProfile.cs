using AutoMapper;
using CodeChallenge.Application.DataTransferObjects;
using CodeChallenge.Domain.Models;

namespace CodeChallenge.Application.Mappings
{
    public class PictureProfile : Profile
    {
        public PictureProfile()
        {
            CreateMap<PictureModel, Picture>();
            CreateMap<Picture, PictureModel>();
        }
    }
}
