using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Supermercado.API.Exceptions.ProdutoException
{
    [Serializable]
    public class ExistenteProdutoException : Exception
    {
        public ExistenteProdutoException() : base() { }
        public ExistenteProdutoException(string message) : base(message) { }
    }
}
