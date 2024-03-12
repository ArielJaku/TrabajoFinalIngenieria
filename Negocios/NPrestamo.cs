using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using Datos;

namespace Negocios
{
    public class NPrestamo
    {
        DPrestamo oDPrestamo = new DPrestamo();
        DUsuario ODUsuario = new DUsuario();
        public int InsertarPrestamo(Prestamo oPrestamo)
        {
            return oDPrestamo.InsertarPrestamo(oPrestamo);

        }
        public int TienePrestamo(Usuario oUsuario)
        {
            return ODUsuario.TienePrestamo(oUsuario);

        }
        public int FinalizarPrestamo(Prestamo oPrestamo)
        {
            return oDPrestamo.FinalizarPrestamo(oPrestamo);
        }
        public Prestamo TraerPrestamo(Usuario usuario)
        {
            
            return oDPrestamo.TraerPrestamo(usuario);
        }

        public int ActualizarPrestamoPorVencer(Prestamo oPrestamo)
        {
            return oDPrestamo.ActualizarPrestamoPorVencer(oPrestamo);
        }
        public int ActualizarPrestamoVencido(Prestamo oPrestamo)
        {
            return oDPrestamo.ActualizarPrestamoVencido(oPrestamo);
        }

    }
}
