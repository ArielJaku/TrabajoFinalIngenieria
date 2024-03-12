using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace Datos
{
    public class DGenero
    {
        #region ABMPURO

        static string conexionstring = "server= DESKTOP-KASPEP1\\SQLEXPRESS; database= LibrosLibres3; integrated security=true";
        SqlConnection con = new SqlConnection(conexionstring);
        public int InsertarGenero(Genero oGenero)
        {
            int flag = 0;
            con.Open();
            string query = "insert into genero values ('" + oGenero.Nombre + "')";
            SqlCommand cmd = new SqlCommand(query, con);
            flag = cmd.ExecuteNonQuery();
            con.Close();
            return flag;

        }
        public int ModificarGenero(Genero oGenero)
        {
            int flag = 0;
            con.Open();
            string query = "update genero set genero='" + oGenero.Nombre + "' where id=" + oGenero.Id;
            SqlCommand cmd = new SqlCommand(query, con);
            flag = cmd.ExecuteNonQuery();
            con.Close();
            return flag;

        }
        public int BorrarGenero(Genero oGenero)
        {
            int flag = 0;
            con.Open();
            string query = "delete from genero where id = " + oGenero.Id;
            SqlCommand cmd = new SqlCommand(query, con);
            flag = cmd.ExecuteNonQuery();
            con.Close();
            return flag;

        }
        public DataTable ConsultarGeneroGV()
        {
            string query = "select * from genero";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter data = new SqlDataAdapter(cmd);
            DataTable tabla = new DataTable();
            data.Fill(tabla);
            return tabla;

        }

        public DataTable ConsultarGeneroGV(Genero oGenero)
        {
            string query = "select * from genero where genero like '%" + oGenero.Nombre + "%';";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter data = new SqlDataAdapter(cmd);
            DataTable tabla = new DataTable();
            data.Fill(tabla);
            return tabla;
        }
    }

    #endregion
}

