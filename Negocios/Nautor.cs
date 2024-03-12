using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;
using System.Data;
using Entidades;
namespace Negocios
{
    public class Nautor
    {
        Dautor NA = new Dautor();
        
        public int NInsertarAutor(string nom, string ape, int pai)
        {
            Autor oAutor = new Autor();
            oAutor.Nombre = nom;
            oAutor.Apellido = ape;
            oAutor.idpais = pai;
            return NA.InsertarAutor(oAutor);

        }

        public DataTable ConsultarAutoresGV()
        {
          
            return NA.ConsultarAutoresGV();
        }

        public DataTable ConsultarAutoresGV(string nom)
        {
            Autor oAutor = new Autor();
            oAutor.Nombre= nom;
            return NA.ConsultarAutoresGV(oAutor);
        }
        public DataTable PaisesCB()
        {
            return NA.ConsultarPaisCB();
        }
        public int ModificarAutor(Autor oAutor)
        {
            return NA.ModificarAutor(oAutor);
        }
        public int BorrarAutor(Autor oAutor)
        {
            return NA.BorrarAutor(oAutor);
        }



    }
}
