using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Devuelto : EstadoPrestamo
    {
        public override void ControlarEstado(Prestamo Ps)
        {
           
        }

        public override string Describir()
        {
            return "Devuelto";
        }
    }
}
