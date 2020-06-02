using Microsoft.EntityFrameworkCore;
using Supermercado.API.Domain.Models;
using Supermercado.API.Domain.Repositories;
using Supermercado.API.Exceptions;
using Supermercado.API.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Supermercado.API.Persistence.Repositories
{
    public class CategoriaRepository : ICategoriaRepository
    {

        private const string nenhuma_categoria_encontrada_menssagem = "Nenhuma Categoria Encontrada";
        private readonly AppDbContext _context;

        public CategoriaRepository(AppDbContext context)
        {
            this._context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<IEnumerable<Categoria>> ListAsync()
        {
            return await _context.Categorias.ToListAsync();
        }

        public async Task<Categoria> GetByIdAsync(Guid id)
        {
           return await _context.Categorias.FindAsync(id);
        }

        public async Task AddAsync(Categoria categoria)
        {
            _context.Categorias.Add(categoria);
            await _context.SaveChangesAsync();

        }

        /*public async Task UpdateAsync(Categoria categoria)
        {
            Categoria categoriaExistente = await _context.Categorias.AsNoTracking().SingleAsync(cat => cat.Id == categoria.Id);


            if (categoriaExistente == null)
            {
                throw new NaoEncontradoCategoriaException(nenhuma_categoria_encontrada_menssagem);
            }

            _context.Entry(categoria).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }*/

       public async Task UpdateAsync(Guid id, Categoria categoria)
        {
            Categoria categoriaExistente = await this.GetByIdAsync(id);


            if (categoriaExistente == null)
            {
                throw new NaoEncontradoCategoriaException(nenhuma_categoria_encontrada_menssagem);
            }

            _context.Entry(categoriaExistente).State = EntityState.Modified;

            categoriaExistente.Nome = categoria.Nome;

            await _context.SaveChangesAsync();
        }

        public async Task RemoveAsync(Categoria categoria)
        {
            _context.Categorias.Remove(categoria);
            await _context.SaveChangesAsync();

        }

    }
}
