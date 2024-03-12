using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Venta
    {
        public int id { get; set; }

        public int dniComprador { get; set; }

        public int dniVendedor { get; set; }

        public int idLibro { get; set; }

        public DateTime fechaVenta { get; set; }

        public int estadoVenta { get; set; }

        
    }
}
