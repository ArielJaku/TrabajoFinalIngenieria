using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Prestamo
    {
        public int id { get; set; }

        public int dniPrestador { get; set; }

        public int dniRecibidor { get; set; }

        public DateTime FechaPrestamo { get; set; }

        public DateTime FechaDevolucion { get; set; }

        public int libro { get; set; }

        public EstadoPrestamo Estado { get; set; }

        public Prestamo()
        {
            Estado = new Activo();
        }

        public void DefinirEstado(EstadoPrestamo estado)
        {
            Estado = estado;
        }
        public void Actualizar()
        {
            Estado.ControlarEstado(this);
        }
    }
}
