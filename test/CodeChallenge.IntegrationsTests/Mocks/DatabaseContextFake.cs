using CodeChallenge.Domain.Abstractions;
using CodeChallenge.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CodeChallenge.IntegrationsTests.Mocks
{
    internal class DatabaseContextFake : IDatabaseContext
    {
        private List<UserModel> _usersModel;

        public DatabaseContextFake()
        {
            _usersModel = new List<UserModel>();
        }

        public async Task<List<UserModel>> GetDataAsync()
        {
            return await Task.FromResult(_usersModel);
        }

        public async Task UpdateDataAsync(List<UserModel> users)
        {
            _usersModel = users;
            await Task.CompletedTask;
        }
    }
}
