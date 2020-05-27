using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Supermercado.API.Exceptions.CategoriaException
{
    [Serializable()]
    public class ParametroInvalidoCategoriaException : Exception
    {
        public ParametroInvalidoCategoriaException() : base() { }
        public ParametroInvalidoCategoriaException(string message) : base(message) { }
    }
}
