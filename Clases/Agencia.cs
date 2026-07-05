using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases
{
    public  class Agencia
    {
        public string nombre;
        public string ciudad;
        public string codigo;
        public override string ToString()
        {
            return $"{nombre} - {ciudad} ({codigo})";
        }
    }
}
