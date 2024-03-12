using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Entidades
{
    public class Autores
    {
        public List<Autor> ListaAutores { get; set; }

        static string conexionstring = "server= DESKTOP-KASPEP1\\SQLEXPRESS; database= LibrosLibres3; integrated security=true";
        SqlConnection con = new SqlConnection(conexionstring);

        public DataTable ConsultarAutoresGV()
        {
            
            //string query = "select * from autores ";
            string query = "select * from autores";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter data = new SqlDataAdapter(cmd);
            DataTable tabla = new DataTable();
            data.Fill(tabla);
            return tabla;

        }
    }
}
