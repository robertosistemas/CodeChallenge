using CodeChallenge.Domain.Abstractions;
using CodeChallenge.Domain.Abstractions.Repositories;
using CodeChallenge.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeChallenge.Infrastructure.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        protected readonly IDatabaseContext DatabaseContext;

        public UserRepository(IDatabaseContext databaseContext)
        {
            DatabaseContext = databaseContext;
        }

        public Task AddAsync(User item)
        {
            throw new NotImplementedException();
        }
        public Task UpdateAsync(Guid id, User item)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<User> GetAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<(List<User> Itens, int TotalCount)> GetAllAsync(IPaged paged)
        {
            var itens = await DatabaseContext.GetDataAsync();
            var skip = (paged.PageNumber - 1) * paged.PageSize;
            if (skip >= itens.Count)
                skip = itens.Count;
            var itensPaged = itens.Skip(skip).Take(paged.PageSize).ToList();
            var result = (itensPaged, itens.Count);
            return await Task.FromResult(result);
        }
    }
}