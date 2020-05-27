using Supermercado.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Supermercado.API.Extensions
{
    public static class CategoriaExtensions
    {
        public static bool IsValid(this Categoria categoria)
        {
            return categoria == null || categoria.Nome == null || "".Equals(categoria.Nome);
        }
    }
}
