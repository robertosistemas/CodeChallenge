using AutoMapper;
using CodeChallenge.Application.DataTransferObjects;
using CodeChallenge.Domain.Models;

namespace CodeChallenge.Application.Mappings
{
    public class UserPagedProfile: Profile
    {
        public UserPagedProfile()
        {
            CreateMap<UserPaged, UserPagedDto>();
            CreateMap<UserPagedDto, UserPaged>();
        }
    }
}
