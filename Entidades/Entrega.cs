using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Entrega
    {
        public int Id { get; set; }

        public int IdVenta { get; set; }

        public int UsuarioCadete { get; set; }

        public DateTime FechaInicio { get; set; }

        public int EstadoEntrega { get; set; } 

        public string DireccionEntregaInicio { get; set; }

        public string DireccionEntregaFin { get; set; }



    }
}
