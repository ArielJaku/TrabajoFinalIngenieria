using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using Datos;
using System.Data;

namespace Negocios
{
    public class NGenero
    {
        DGenero oDGenero = new DGenero();

        public int InsertarGenero(Genero oGenero)
        {
            return oDGenero.InsertarGenero(oGenero);

        }
        public int ModificarGenero(Genero oGenero)
        {

            return oDGenero.ModificarGenero(oGenero);

        }
        public int BorrarGenero(Genero oGenero)
        {

            return oDGenero.BorrarGenero(oGenero);

        }
        public DataTable ConsultarGenerosGV()
        {

            return oDGenero.ConsultarGeneroGV();

        }

        public DataTable ConsultarGenerosGV(Genero oGenero)
        {
            return oDGenero.ConsultarGeneroGV(oGenero);
        }
    
}
}
