using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CodeChallenge.Domain.Abstractions.Repositories
{
    public interface IRepository<T>
    {
        Task Add(T item);
        Task Update(Guid id, T item);
        Task Delete(Guid id);
        Task<T> Get(Guid id);
        Task<(IEnumerable<T> Itens, int TotalCount)> GetAll(IPaged paged);
    }
}
