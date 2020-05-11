using Supermercado.API.Domain.Models;
using Supermercado.API.Domain.Repositories;
using Supermercado.API.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Supermercado.API.Services
{
    public class CategoriaService : ICategoriaService
    {
        private readonly ICategoriaRepository _categoriaRepository;

        public CategoriaService(ICategoriaRepository categoriaRepository) 
        {
            _categoriaRepository = categoriaRepository;
        }

        public async Task<Categoria> GetByIdAsync(int id)
        {
            return await this._categoriaRepository.FindByIdAsync(id);
        }

        public async Task<IEnumerable<Categoria>> ListAsync()
        {
            return await _categoriaRepository.ListAsync();
        }

        public async Task AddAsync(Categoria categoria) {
            await _categoriaRepository.AddAsync(categoria);
        }

        public async void Remove(Categoria categoria)
        {
            _categoriaRepository.Remove(categoria);
        }

        public async void Update(Categoria categoria)
        {
            _categoriaRepository.Update(categoria);
        }
    }
}
