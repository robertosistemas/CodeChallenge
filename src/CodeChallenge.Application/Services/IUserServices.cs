using CodeChallenge.Application.DataTransferObjects;
using System;
using System.Threading.Tasks;

namespace CodeChallenge.Application.Services
{
    public interface IUserServices
    {
        Task<Guid> AddAsync(User user);
        Task UpdateAsync(Guid id, User user);
        Task DeleteAsync(Guid id);
        Task<User> GetAsync(Guid id);
        Task<UsersResult> GetAllAsync(UserPaged userPaged);
    }
}
