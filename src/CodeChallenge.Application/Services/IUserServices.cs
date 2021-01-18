using CodeChallenge.Application.DataTransferObjects;
using System;
using System.Threading.Tasks;

namespace CodeChallenge.Application.Services
{
    public interface IUserServices
    {
        Task<Guid> AddAsync(UserDto userDto);
        Task UpdateAsync(Guid id, UserDto userDto);
        Task DeleteAsync(Guid id);
        Task<UserDto> GetAsync(Guid id);
        Task<UsersResultDto> GetAllAsync(UserPagedDto userPagedDto);
    }
}
