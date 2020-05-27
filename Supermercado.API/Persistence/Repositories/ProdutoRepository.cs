using Microsoft.EntityFrameworkCore;
using Supermercado.API.Domain.Models;
using Supermercado.API.Domain.Repositories;
using Supermercado.API.Exceptions.ProdutoException;
using Supermercado.API.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Supermercado.API.Persistence.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {

        private const string nenhum_produto_encontrado_menssagem = "Nenhum Produto Encontrado";
        protected readonly AppDbContext _context;

        public ProdutoRepository(AppDbContext context) 
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<IEnumerable<Produto>> ListAsync()
        {
            return await _context.Produtos.ToListAsync();
        }

        public async Task<Produto> GetByIdAsync(Guid id)
        {
            return await _context.Produtos.FindAsync(id);
        }

        public async Task AddAsync(Produto produto)
        {
            _context.Produtos.Add(produto);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Produto produto)
        {
            Produto produtoExistente = await _context.Produtos.AsNoTracking().SingleAsync((prod) => prod.Id == produto.Id);

            if (produtoExistente == null) 
                throw new NaoEncontradoProdutoException(nenhum_produto_encontrado_menssagem);

            _context.Entry(produto).State = EntityState.Modified;
            await _context.SaveChangesAsync(); 
        }

        public async Task RemoveAsync(Produto produto)
        {
            _context.Produtos.Remove(produto);
            await _context.SaveChangesAsync();
        }
    }
}
