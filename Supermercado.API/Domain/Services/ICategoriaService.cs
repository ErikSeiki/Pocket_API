using Supermercado.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Supermercado.API.Domain.Services
{
    public interface ICategoriaService
    {
        /// <summary>
        /// Listar todas as categorias de produtos
        /// </summary>
        /// <returns>Lista de categorias</returns>
        Task<IEnumerable<Categoria>> ListAsync();

        /// <summary>
        /// Obtém uma categoria por ID
        /// </summary>
        /// <param name="id">ID da categoria</param>
        /// <returns>Categoria encontrada</returns>
        Task<Categoria> GetByIdAsync(Guid id);

        /// <summary>
        /// Adiciona uma nova categoria
        /// </summary>
        /// <param name="categoria">Objeto (instancia) do tipo Categoria</param>
        /// <returns>Categoria adicionado</returns>
        Task<Categoria> AddAsync(Categoria categoria);

        /// <summary>
        /// Atualiza uma categoria
        /// </summary>
        /// <param name="categoria">Objeto (Instancia) do tipo Categoria</param>
        Task UpdateAsync(Categoria categoria);

        /// <summary>
        /// Remover uma categoria
        /// </summary>
        /// <param name="categoria">ID da Categoria</param>
        Task RemoveAsync(Guid id);


    }
}
