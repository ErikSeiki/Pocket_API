using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Supermercado.API.Exceptions.CategoriaException
{
    [Serializable()]
    public class ExistenteCategoriaException : Exception
    {
        public ExistenteCategoriaException() : base() { }
        public ExistenteCategoriaException(string message) : base(message) { }
    }
}
