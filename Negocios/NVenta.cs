using Datos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocios
{
    public class NVenta
    {
        DVenta DatosVenta = new DVenta();
        public int ingresarVenta(Venta oVenta, Usuario oUsuario)
        {
            return DatosVenta.ingresarVenta(oVenta, oUsuario);
        }

        public Venta traerVenta(Venta oVenta)
        {
            return DatosVenta.traerVenta(oVenta);
        }
    }
}
