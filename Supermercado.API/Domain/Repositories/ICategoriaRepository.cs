using Supermercado.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Supermercado.API.Domain.Repositories
{
    public interface ICategoriaRepository 
    {
        Task<IEnumerable<Categoria>> ListAsync();
        Task<Categoria> GetByIdAsync(Guid id);
        Task AddAsync(Categoria categoria);
        Task UpdateAsync(Guid id, Categoria categoria);
        Task RemoveAsync(Categoria categoria);

    }
}
