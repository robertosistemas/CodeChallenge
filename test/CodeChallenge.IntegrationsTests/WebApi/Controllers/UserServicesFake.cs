using CodeChallenge.Application.DataTransferObjects;
using CodeChallenge.Application.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CodeChallenge.IntegrationsTests.WebApi.Controllers
{
    public class UserServicesFake : IUserServices
    {
        public async Task<Guid> AddAsync(UserDto userDto)
        {
            return await Task.FromResult(Guid.NewGuid());
        }

        public async Task DeleteAsync(Guid id)
        {
            await Task.CompletedTask;
        }

        public async Task<UsersResultDto> GetAllAsync(UserPagedDto userPagedDto)
        {
            var usersResult = new UsersResultDto() { Users = new List<UserDto>() { new UserDto() } };
            return await Task.FromResult(usersResult);
        }

        public async Task<UserDto> GetAsync(Guid id)
        {
            return await Task.FromResult(new UserDto());
        }

        public async Task UpdateAsync(Guid id, UserDto userDto)
        {
            await Task.CompletedTask;
        }
    }
}
