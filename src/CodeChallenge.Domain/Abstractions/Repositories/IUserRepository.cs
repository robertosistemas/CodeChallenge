using CodeChallenge.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CodeChallenge.Domain.Abstractions.Repositories
{
    public interface IUserRepository
    {
        Task AddAsync(User item);
        Task UpdateAsync(Guid id, User item);
        Task DeleteAsync(Guid id);
        Task<User> GetAsync(Guid id);
        Task<(List<User> Itens, int TotalCount)> GetAllAsync(IPaged paged);
    }
}
