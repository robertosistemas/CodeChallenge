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

        public async Task<Guid> AddAsync(User item)
        {
            var users = await DatabaseContext.GetDataAsync();
            item.Id = Guid.NewGuid();
            // Incluir registro na lista, salvar em disco, recarregar cache
            return item.Id;
        }
        public async Task UpdateAsync(Guid id, User item)
        {
            var users = await DatabaseContext.GetDataAsync();
            var user = users.FirstOrDefault(f => f.Id.Equals(id));
            if (user == null)
            {
                // Atualizar registro na lista, salvar em disco, recarregar cache
            }
        }

        public async Task DeleteAsync(Guid id)
        {
            var users = await DatabaseContext.GetDataAsync();
            var user = users.FirstOrDefault(f => f.Id.Equals(id));
            if (user == null)
            {
                // remover da lista, salvar em disco, recarregar cache
            }
        }

        public async Task<User> GetAsync(Guid id)
        {
            var users = await DatabaseContext.GetDataAsync();
            return users.FirstOrDefault(f => f.Id.Equals(id));
        }

        public async Task<(List<User> Itens, int TotalCount)> GetAllAsync(UserPaged userPaged)
        {
            var users = await DatabaseContext.GetDataAsync();

            if (!string.IsNullOrWhiteSpace(userPaged.Region))
                users = users.Where(f => f.Location.Region != null && f.Location.Region.Equals(userPaged.Region)).ToList();

            if (!string.IsNullOrWhiteSpace(userPaged.Type))
                users = users.Where(f => f.Type != null && f.Type.Equals(userPaged.Type)).ToList();

            var skip = (userPaged.PageNumber - 1) * userPaged.PageSize;
            if (skip >= users.Count)
                skip = users.Count;
            var itensPaged = users.Skip(skip).Take(userPaged.PageSize).ToList();
            var result = (itensPaged, users.Count);
            return await Task.FromResult(result);
        }
    }
}