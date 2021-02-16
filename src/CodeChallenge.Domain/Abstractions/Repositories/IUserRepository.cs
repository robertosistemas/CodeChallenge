using CodeChallenge.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CodeChallenge.Domain.Abstractions.Repositories
{
    public interface IUserRepository
    {
        Task<Guid> AddAsync(UserModel user);
        Task UpdateAsync(Guid id, UserModel user);
        Task DeleteAsync(Guid id);
        Task<UserModel?> GetAsync(Guid id);
        Task<(List<UserModel> Itens, int TotalCount)> GetAllAsync(UserPagedModel userPaged);
    }
}
