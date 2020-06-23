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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Produto>()
                .HasOne(pro => pro.Categoria)
                .WithMany(cat => cat.Produtos)
                .HasForeignKey(pro => pro.CategoriaId)
                .HasPrincipalKey(cat => cat.Id)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
