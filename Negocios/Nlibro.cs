using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Datos;
using Entidades;

namespace Negocios
{
    public class Nlibro
    {
        Dlibro NL = new Dlibro();
        public int Insertarlibro(int isbn, string nom, int aut)
        {
           Libro oLibro = new Libro();
           oLibro.isbn = isbn;
            oLibro.nombre = nom;
            oLibro.idAutor = aut;

            
            return NL.Insertarlibro(oLibro);


        }

        public DataTable ConsultarLibrosGV()
        {
            return NL.ConsultarLibrosGV();
        }

        public DataTable ConsultarLibrosGV1()
        {
            return NL.ConsultarLibrosGV1();
        }

        public DataTable ConsultarLibrosGV1(Libro oLibro)
        {
            return NL.ConsultarLibrosGV1(oLibro);
        }

        public DataTable ConsultarLibrosGV(string nomb)
        {
            Libro oLibro = new Libro();
            oLibro.nombre = nomb;
            return NL.ConsultarLibrosGV(oLibro);
        }

        public DataTable TraerAutores()
        {
            
            return NL.TraerAutores();
        }

        public DataTable TraerEditoriales()
        {
         
            return NL.TraerEditoriales();
        }

        public int InsertarlibroUsuario(int isbn, string nom, int aut, int edi, int dni)
        {

            return NL.InsertarlibroUsuario(isbn, nom, aut, edi, dni);

        }

        public DataTable TraerMasBuscados()
        {
        
            return NL.TraerMasBuscados();
        }


        public DataTable TraerMasCargados()
        {
          
            return NL.TraerMasCargados();
        }

        public DataTable TraerDuenos(Libro oLibro)
        {

            return NL.TraerDuenos(oLibro);
        }

        public int BorrarLibro(Libro oLibro)
        {
            
            return NL.BorrarLibro(oLibro);

        }

        public int ModificarLibro(Libro oLibro)
        {
            return NL.ModificarLibro(oLibro);
        }

        public int CargarLibro(Libro oLibro)
        {
            return NL.CargarLibro(oLibro);
        }

        public int SumarReporteBusqueda(Libro oLibro)
        {
            
            return NL.SumarReporteBusqueda(oLibro);

        }
        public int cantidadLibros()
        {
            return NL.cantidadLibros();

        }
        public int SumarReporteGenero(Libro oLibro)
        {
            return NL.SumarReporteGenero(oLibro);

        }

        #region NuevoLibros

        #endregion
    }
}
