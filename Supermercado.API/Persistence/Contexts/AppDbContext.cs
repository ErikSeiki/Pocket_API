using Microsoft.EntityFrameworkCore;
using Supermercado.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Supermercado.API.Persistence.Contexts
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
   

        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Produto> Produtos { get; set; }

        /*protected override void OnModelCreating(ModelBuilder modelBuilder)
          {
              modelBuilder.Entity<Produto>()
                  .HasOne(prod => prod.Categoria)
                  .WithMany(cat => cat.Produtos)
                  .HasForeignKey(produto => produto.CategoriaId);
          }*/

        /*protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("supermercado-api-in-memory");
        }*/
    }
}
