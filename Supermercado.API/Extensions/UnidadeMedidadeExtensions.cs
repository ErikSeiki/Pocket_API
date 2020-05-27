using Supermercado.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Supermercado.API.Extensions
{
    public static class UnidadeMedidadeExtensions
    {
        public static bool IsValid(this UnidadeMedidaEnum unidadeMedidaEnum) 
        {
            return unidadeMedidaEnum != UnidadeMedidaEnum.Unidade && unidadeMedidaEnum != UnidadeMedidaEnum.Miligrama &&
                unidadeMedidaEnum != UnidadeMedidaEnum.Litro && unidadeMedidaEnum != UnidadeMedidaEnum.Kilograma &&
                unidadeMedidaEnum != UnidadeMedidaEnum.Grama;
        }
    }
}
