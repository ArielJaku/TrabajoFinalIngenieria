using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using Datos;

namespace Negocios
{
    public class NDonacion
    {
        DDonacion ND = new DDonacion();
        public int GenerarDonacion(Donacion oDonacion)
        {
            return ND.GenerarDonacion(oDonacion);
        }
        public int SumarReporteGenero(Donacion oDonacion)
        {
            return ND.SumarReporteGenero(oDonacion);

        }
    }
}
