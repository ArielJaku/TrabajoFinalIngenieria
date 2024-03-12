using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;
using System.Data;
using Entidades;
using System.Data.SqlClient;

namespace Negocios
{
    public class Nejemplar
    {
        DEjemplar NE = new DEjemplar();

        public int InsertarEjemplar(int isbn, int dni, int año, int editorial, byte[] imagen1, byte[] imagen2)
        {
            Ejemplares oEjemplar = new Ejemplares();
            oEjemplar.año = año;
            oEjemplar.Ideditorial = editorial;
            oEjemplar.imagen1 = imagen1;
            oEjemplar.imagen2 = imagen2;
           
            return NE.InsertarEjemplar(isbn,dni,oEjemplar);

        }
        public int InsertarEjemplar2(int isbn, int dni, int año, int editorial, byte[] imagen1, byte[] imagen2, decimal precio)
        {
            try
            {
                Ejemplares oEjemplar = new Ejemplares();
                oEjemplar.año = año;
                oEjemplar.Ideditorial = editorial;
                oEjemplar.imagen1 = imagen1;
                oEjemplar.imagen2 = imagen2;
                oEjemplar.precio = precio;
                return NE.InsertarEjemplar2(isbn, dni, oEjemplar);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            

        }

        public DataTable TraerEjemplar(int dni, int idLibro)
        {
            return NE.TraerEjemplar(dni,idLibro);
        }
        public int cantidadEjemplares()
        {
            return NE.cantidadEjemplares();

        }
        public int ModificarEstadoEjemplar(Ejemplares oEjemplar)
        {
            return NE.ModificarEstadoEjemplar(oEjemplar);
        }
        public int SumarReporteGenero(Ejemplares oEjemplar)
        {
            
            return NE.SumarReporteGenero(oEjemplar);

        }
        public int SumarStockLibro(Ejemplares oEjemplar)
        {

            return NE.SumarStockLibro(oEjemplar);

        }

        public DataTable TraerEjemplares()
        {
            return NE.TraerEjemplares();
        }

        public DataTable BuscarPorNombre(string Nombre)
        {
            return NE.BuscarPorNombre(Nombre);
        }

        public DataTable BuscarPorGenero(string Genero)
        {
            return NE.BuscarPorGenero(Genero);
        }

        public DataTable BuscarPorEscritor(string Escritor)
        {
            return NE.BuscarPorEscritor(Escritor);
        }

    }
}
