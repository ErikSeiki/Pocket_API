using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Supermercado.API.Domain.Models
{
    public enum UnidadeMedidaEnum : byte
    {
        [Description("UN")]
        Unidade = 1,

        [Description("MG")]
        Miligrama = 2,

        [Description("G")]
        Grama = 3,

        [Description("KG")]
        Kilograma = 4,

        [Description("L")]
        Litro = 5

    }
}
