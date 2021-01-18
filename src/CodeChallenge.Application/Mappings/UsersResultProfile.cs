using AutoMapper;
using CodeChallenge.Application.DataTransferObjects;
using CodeChallenge.Domain.Models;

namespace CodeChallenge.Application.Mappings
{
    public class UsersResultProfile: Profile
    {
        public UsersResultProfile()
        {
            CreateMap<UsersResult, UsersResultDto>();
            CreateMap<UsersResultDto, UsersResult>();
        }
    }
}
