using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Supermercado.API.Exceptions
{
    [Serializable()]
    public class NaoEncontradoCategoriaException: Exception
    {
        public NaoEncontradoCategoriaException() : base(){ }
        public NaoEncontradoCategoriaException(string message) : base(message) { }
    }
}
   