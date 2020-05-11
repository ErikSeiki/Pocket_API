using Supermercado.API.Domain.Models;
using Supermercado.API.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Supermercado.API.Repository
{
    public class CategoriaRepository : ICategoriaRepository
    {
        private List<Categoria> categorias;

        public CategoriaRepository()
        
        {
            this.categorias = new List<Categoria>
            {
                new Categoria
                {
                    Id = 8,
                    Produtos = new List<Produto>
                    {
                        new Produto()
                        {
                            Id = 2,
                            Nome = "Feijão"
                        }
                    }
                },
                new Categoria
                {
                    Id = 10
                }
            };
        }

        public async Task AddAsync(Categoria categoria)
        {
            this.categorias.Add(categoria);
        }

        public async Task<Categoria> FindByIdAsync(int id)
        {
            return this.categorias.Find(cat => cat.Id == id);
        }

        public async Task<IEnumerable<Categoria>> ListAsync()
        {
            return this.categorias;
        }

        public void Remove(Categoria categoria)
        {
            this.categorias.Remove(categoria);
        }

        public void Update(Categoria categoria)
        {
            Categoria categoriaExistente = this.categorias.Find(cat => categoria.Id == cat.Id);
            if (categoriaExistente != null)
            {
                int pos = this.categorias.IndexOf(categoriaExistente);
                this.categorias[pos] = categoria;
            }
            else 
            {
                categorias.Add(categoria);            
            }
        }
    }
}
