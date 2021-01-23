using AutoMapper;
using CodeChallenge.Application.DataTransferObjects;
using CodeChallenge.Domain.Models;

namespace CodeChallenge.Application.Mappings
{
    public class UserPagedProfile: Profile
    {
        public UserPagedProfile()
        {
            CreateMap<UserPagedModel, UserPaged>();
            CreateMap<UserPaged, UserPagedModel>();
        }
    }
}
