using AutoMapper;
using CodeChallenge.Application.DataTransferObjects;
using CodeChallenge.Domain.Models;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace CodeChallenge.Application.Mappings
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserModel, User>();
            CreateMap<User, UserModel>();

            CreateMap<UserImportModel, UserModel>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => System.Guid.NewGuid()))
                .ForMember(dest => dest.Type, opt => opt.MapFrom(new UserTypeResolver()))
                .ForMember(dest => dest.Gender, opt => opt.MapFrom(src => src.Gender.Equals("male") ? "m" : "f"))
                .ForMember(dest => dest.Birthday, opt => opt.MapFrom(src => src.Dob.Date))
                .ForMember(dest => dest.Registered, opt => opt.MapFrom(src => src.Registered.Date))
                .ForMember(dest => dest.TelephoneNumbers, opt => opt.MapFrom(src => TransformPhoneNumber(src.Phone)))
                .ForMember(dest => dest.MobileNumbers, opt => opt.MapFrom(src => TransformPhoneNumber(src.Cell)))
                .ForMember(dest => dest.Nationality, opt => opt.MapFrom(src => "BR"))
                .AfterMap((src, dest) => dest.Location.Region = EstadosRegioes[src.Location.State]);
        }

        private static string OnlyNumbers(string text)
        {
            return Regex.Replace(text, @"[^\d]", "");
        }

        private static List<string> TransformPhoneNumber(string number)
        {
            return new List<string> { $"+55{OnlyNumbers(number)}" };
        }

        private static readonly Dictionary<string, string> EstadosRegioes = new()
            {
                { "acre", "norte" },
                { "alagoas", "nordeste" },
                { "amapá", "norte" },
                { "amazonas", "norte" },
                { "bahia", "nordeste" },
                { "ceará", "nordeste" },
                { "distrito federal", "centro-oeste" },
                { "espírito santo", "sudeste" },
                { "goiás", "centro-oeste" },
                { "maranhão", "nordeste" },
                { "mato grosso", "centro-oeste" },
                { "mato grosso do sul", "centro-oeste" },
                { "minas gerais", "sudeste" },
                { "pará", "norte" },
                { "paraíba", "nordeste" },
                { "paraná", "sul" },
                { "pernambuco", "nordeste" },
                { "piauí", "nordeste" },
                { "rio de janeiro", "sudeste" },
                { "rio grande do norte", "nordeste" },
                { "rio grande do sul", "sul" },
                { "rondônia", "norte" },
                { "roraima", "norte" },
                { "santa catarina", "sul" },
                { "são paulo", "sudeste" },
                { "sergipe", "nordeste" },
                { "tocantins", "norte" }
            };
    }
}