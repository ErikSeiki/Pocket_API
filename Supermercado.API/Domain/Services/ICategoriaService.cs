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
        Task<Categoria> GetByIdAsync(int id);

        /// <summary>
        /// Adicionar uma nova categoria
        /// </summary>
        /// <param name="categoria">Objeto (Instancia) do tipo Categoria</param>
        /// <returns></returns>
        Task AddAsync(Categoria categoria);

        /// <summary>
        /// Remover uma categoria
        /// </summary>
        /// <param name="categoria">Objeto (Instancia) do tipo Categoria</param>
        void Remove(Categoria categoria);

        /// <summary>
        /// Atualizar uma categoria
        /// </summary>
        /// <param name="categoria">Objeto (Instancia) do tipo Categoria</param>
        void Update(Categoria categoria);
    }
}
