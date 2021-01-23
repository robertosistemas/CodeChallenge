using CodeChallenge.Application.DataTransferObjects;
using CodeChallenge.Application.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CodeChallenge.IntegrationsTests.WebApi.Controllers
{
    public class UserServicesFake : IUserServices
    {
        public async Task<Guid> AddAsync(User user)
        {
            return await Task.FromResult(Guid.NewGuid());
        }

        public async Task DeleteAsync(Guid id)
        {
            await Task.CompletedTask;
        }

        public async Task<UsersResult> GetAllAsync(UserPaged userPaged)
        {
            var usersResult = new UsersResult() { Users = new List<User>() { new User() } };
            return await Task.FromResult(usersResult);
        }

        public async Task<User> GetAsync(Guid id)
        {
            return await Task.FromResult(new User());
        }

        public async Task UpdateAsync(Guid id, User user)
        {
            await Task.CompletedTask;
        }
    }
}
