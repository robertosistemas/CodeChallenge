using AutoMapper;
using CodeChallenge.Application.DataTransferObjects;
using CodeChallenge.Domain.Models;

namespace CodeChallenge.Application.Mappings
{
    public class UsersResultProfile: Profile
    {
        public UsersResultProfile()
        {
            CreateMap<UsersResultModel, UsersResult>();
            CreateMap<UsersResult, UsersResultModel>();
        }
    }
}
