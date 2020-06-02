using Supermercado.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Supermercado.API.Domain.Repositories
{
    public interface IProdutoRepository
    {
        Task<IEnumerable<Produto>> ListAsync();
        Task<Produto> GetByIdAsync(Guid id);
        Task AddAsync(Produto produto);
        Task RemoveAsync(Produto produto);
        Task UpdateAsync(Guid id, Produto produto);
    }
}
