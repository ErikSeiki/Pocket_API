using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Supermercado.API.Exceptions.ProdutoException
{
    [Serializable]
    public class ParametroInvalidoProdutoException : Exception
    {
        public ParametroInvalidoProdutoException() : base() { }
        public ParametroInvalidoProdutoException(string message) : base(message) { }
    }
}
