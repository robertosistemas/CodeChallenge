using CodeChallenge.Application.DataTransferObjects;
using System.Threading.Tasks;

namespace CodeChallenge.Application.Services
{
    public interface IUserServices
    {
        Task<UsersResultDto> GetUsersAsync(UserPagedDto userPagedDto);
    }
}
