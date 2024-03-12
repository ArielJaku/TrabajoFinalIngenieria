using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public abstract class EstadoPrestamo
    {
        public abstract void ControlarEstado(Prestamo Ps);

        public abstract string Describir();
    }
}
