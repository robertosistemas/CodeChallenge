using AutoMapper;
using CodeChallenge.Application.DataTransferObjects;
using CodeChallenge.Domain.Mappings;
using CodeChallenge.Domain.Models;
using System.Collections.Generic;

namespace CodeChallenge.Application.Mappings
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserDto>();
            CreateMap<UserDto, User>();

            CreateMap<UserImport, User>()
                .ForMember(dest => dest.Type, opt => opt.MapFrom(new UserTypeResolver()))
                .ForMember(dest => dest.Gender, opt => opt.MapFrom(src => src.Gender.Equals("male") ? "m" : "f"))
                .ForMember(dest => dest.Birthday, opt => opt.MapFrom(src => src.Dob.Date))
                .ForMember(dest => dest.Registered, opt => opt.MapFrom(src => src.Registered.Date))
                .ForMember(dest => dest.TelephoneNumbers, opt => opt.MapFrom(src => new List<string> { src.Phone }))
                .ForMember(dest => dest.MobileNumbers, opt => opt.MapFrom(src => new List<string> { src.Cell }))
                .ForMember(dest => dest.Nationality, opt => opt.MapFrom(src => "BR"));
        }
    }
}
