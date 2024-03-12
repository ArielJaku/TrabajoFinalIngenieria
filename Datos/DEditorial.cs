using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using System.Data;
using System.Data.SqlClient;

namespace Datos
{
    public class DEditorial
    {
        static string conexionstring = "server= DESKTOP-KASPEP1\\SQLEXPRESS; database= LibrosLibres3; integrated security=true";
        SqlConnection con = new SqlConnection(conexionstring);
        public int InsertarEditorial(Editorial oEditorial)
        {
            int flag = 0;
            con.Open();
            string query = "insert into editoriales values ('"+ oEditorial.nombre +"')";
            SqlCommand cmd = new SqlCommand(query, con);
            flag = cmd.ExecuteNonQuery();
            con.Close();
            return flag;

        }
        public int ModificarEditorial(Editorial oEditorial)
        {
            int flag = 0;
            con.Open();
            string query = "update editoriales set editorial='" + oEditorial.nombre + "' where id=" + oEditorial.id;
            SqlCommand cmd = new SqlCommand(query, con);
            flag = cmd.ExecuteNonQuery();
            con.Close();
            return flag;

        }
        public int BorrarEditorial(Editorial oEditorial)
        {
            int flag = 0;
            con.Open();
            string query = "delete from editoriales where id = " + oEditorial.id;
            SqlCommand cmd = new SqlCommand(query, con);
            flag = cmd.ExecuteNonQuery();
            con.Close();
            return flag;

        }
        public DataTable ConsultarEditorialesGV()
        {            
            string query = "select * from editoriales";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter data = new SqlDataAdapter(cmd);
            DataTable tabla = new DataTable();
            data.Fill(tabla);
            return tabla;

        }

        public DataTable ConsultarEditorialGV(Editorial oEditorial)
        {
            string query = "select * from editoriales where editorial like '%" + oEditorial.nombre + "%';";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter data = new SqlDataAdapter(cmd);
            DataTable tabla = new DataTable();
            data.Fill(tabla);
            return tabla;
        }
    }
}
