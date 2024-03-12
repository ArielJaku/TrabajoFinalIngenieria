using Datos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocios
{
    public class NEntrega
    {
        DEntregas Datos = new DEntregas();
        public List<Entrega> listaDeEntregas()
        {
            return Datos.listaDeEntregas();
        }

        public int EntregaNueva(Entrega oEntrega)
        {
            
            oEntrega.UsuarioCadete = 35550455;
            oEntrega.EstadoEntrega = 1;
            var check = Datos.EntregaNueva(oEntrega);
            if(check == 1)
            {
                //traigo el id de la entrega recientemente insertada
                var entregaID = Datos.traerUltimaEntrega();
                oEntrega.Id = entregaID.Id;
                return Datos.InsertarDirecciones(oEntrega);
            }
            else
            {
                return 0;
            }
        }
        public Entrega traerEntrega(int idEntrega)
        {
            return Datos.traerEntrega(idEntrega);
        }

        public int cambiarEstadoEntrega(int idEntrega)
        {
            return Datos.cambiarEstadoEntrega(idEntrega);
        }

        public List<Entrega> listaDeEntregasPendientes(int dni)
        {
            return Datos.listaDeEntregasPendientes(dni);

        }
    }
}
