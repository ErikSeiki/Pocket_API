using Supermercado.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace Supermercado.API.Extensions
{
    public static class ProdutoExtensions
    {
        public static bool IsValid(this Produto produto) 
        {
            return produto == null || produto.Id == null || produto.Nome == null || "".Equals(produto.Nome)
                || produto.QuantidadePacote <= 0 || produto.UnidadeMedida.IsValid() || produto.CategoriaId.Equals(Guid.Empty);
        }
    }
}
