using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class PorVencer : EstadoPrestamo
    {
        public override void ControlarEstado(Prestamo Ps)
        {
            DateTime Fecha = DateTime.Now;
            if (Ps.FechaDevolucion.Subtract(Fecha).Days <= 0)
            {
                Ps.DefinirEstado(new Vencido());
            }
            
        }

        public override string Describir()
        {
            return "PorVencer";
        }


    }
}
