using Supermercado.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Supermercado.API.Domain.Services
{
    public interface IProdutoService
    {
        /// <summary>
        /// Listar todos os produtos
        /// </summary>
        /// <returns>Lista de produtos</returns>
        Task<IEnumerable<Produto>> ListAsync();
        
        /// <summary>
        /// Obtém um protudo por ID
        /// </summary>
        /// <param name="id">ID do Produto</param>
        /// <returns>Produto encontrado</returns>
        Task<Produto> GetByIdAsync(Guid id);
        
        /// <summary>
        /// Adiciona um novo produto
        /// </summary>
        /// <param name="produto">Objeto (instancia) do tipo produto</param>
        /// <returns>Produto adicionado</returns>
        Task<Produto> AddAsync(Produto produto);

        /// <summary>
        /// Atualiza um produto 
        /// </summary>
        /// <param name="id">ID do Produto</param>
        /// <param name="produto">Objeto (instancia) do tipo produto</param>
        /// <returns>Objeto (instancia) do tipo produto</returns>
        Task UpdateAsync(Guid id, Produto produto);

        /// <summary>
        /// Remove um produto
        /// </summary>
        /// <param name="id">ID do Produto</param>
        /// <returns></returns>
        Task RemoveAsync(Guid id);
    }
}
