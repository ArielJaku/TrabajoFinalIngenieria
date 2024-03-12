using Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Entidades
{
    public class Activo : EstadoPrestamo
    {
        public override void ControlarEstado(Prestamo Ps)
        {
            DateTime Fecha = DateTime.Now;
            if(Ps.FechaDevolucion.Subtract(Fecha).Days <= 5)
            {
                Ps.DefinirEstado(new PorVencer());             
                
                
            }
            
        }

        public override string Describir()
        {
            return "Activo";

        }
    }
}
