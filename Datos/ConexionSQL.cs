using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Datos
{
    public class ConexionSQL
    {
        static string conexionstring = "server= DESKTOP-KASPEP1\\SQLEXPRESS; database= LibrosLibres3; integrated security=true";
        SqlConnection con = new SqlConnection(conexionstring);

        #region Usuarios
        public int consultalogin(string Usuario, string Contraseña)
        {
            int count;
            con.Open();
            string Query = "select count(*) from persona where usuario = '" + Usuario + "' and contraseña = '" + Contraseña + "'";
            SqlCommand cmd = new SqlCommand(Query, con);
            count = Convert.ToInt32(cmd.ExecuteScalar());
            con.Close();
            return count;

        }


        #endregion
        #region LIBROS 

        public DataTable ConsultarMasBuscados()
        {
            string query = "select * from MasBuscados";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter data = new SqlDataAdapter(cmd);
            DataTable tabla = new DataTable();
            data.Fill(tabla);
            return tabla;
        }

        public DataTable ConsultarMasCargados()
        {
            string query = "select * from MasCargados";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter data = new SqlDataAdapter(cmd);
            DataTable tabla = new DataTable();
            data.Fill(tabla);
            return tabla;
        }

        #endregion


    }
}
