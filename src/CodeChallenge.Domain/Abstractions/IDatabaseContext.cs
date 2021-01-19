using CodeChallenge.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CodeChallenge.Domain.Abstractions
{
    public interface IDatabaseContext
    {
        Task<List<User>> GetDataAsync();
        Task UpdateDataAsync(List<User> users);
    }
}
