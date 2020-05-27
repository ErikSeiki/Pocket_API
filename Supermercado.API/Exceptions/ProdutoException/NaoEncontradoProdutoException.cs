using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Supermercado.API.Exceptions.ProdutoException
{
    [Serializable]
    public class NaoEncontradoProdutoException: Exception
    {
        public NaoEncontradoProdutoException() : base() { }
        public NaoEncontradoProdutoException(string message) : base(message) { }

    }
}
