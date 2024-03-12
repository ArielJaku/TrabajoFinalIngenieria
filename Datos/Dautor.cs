using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Entidades;

namespace Datos
{
    public class Dautor
    {
        #region ADO.NET
        static string conexionstring = "server= DESKTOP-KASPEP1\\SQLEXPRESS; database= LibrosLibres3; integrated security=true";
        SqlConnection con = new SqlConnection(conexionstring);
        Auditoria oAuditoria = new Auditoria();

        public int InsertarAutor(Autor oAutor)
        {
            int flag = 0;
            con.Open();
            string query = "insert into autores values ('" + oAutor.Nombre + "','" + oAutor.Apellido + "','" + oAutor.idpais + "')";
            SqlCommand cmd = new SqlCommand(query, con);
            flag = cmd.ExecuteNonQuery();
            con.Close();            
            return flag;

        }        
        
        public DataTable ConsultarAutoresGV()
        {                        
            Autores oAutores = new Autores();
            return oAutores.ConsultarAutoresGV();

        }

        public DataTable ConsultarAutoresGV(Autor oAutor)
        {
            string query = "select * from autores where nombre like '%" + oAutor.Nombre + "%';";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter data = new SqlDataAdapter(cmd);
            DataTable tabla = new DataTable();
            data.Fill(tabla);
            return tabla;
        }

        public DataTable ConsultarPaisCB()
        {
            string query = "select * from paises";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter data = new SqlDataAdapter(cmd);
            DataTable tabla = new DataTable();
            data.Fill(tabla);
            return tabla;
        }

        #endregion
        public int ModificarAutor(Autor oAutor)
        {
            int flag = 0;
            con.Open();
            string query = "update autores set nombre='" + oAutor.Nombre + "', apellido='" + oAutor.Apellido + "',pais=" + oAutor.idpais + " where id=" + oAutor.Id;
            SqlCommand cmd = new SqlCommand(query, con);
            flag = cmd.ExecuteNonQuery();
            con.Close();
            return flag;

        }
        public int BorrarAutor(Autor oAutor)
        {
            int flag = 0;
            con.Open();
            string query = "delete from autores where id = " + oAutor.Id;
            SqlCommand cmd = new SqlCommand(query, con);
            flag = cmd.ExecuteNonQuery();
            con.Close();
            return flag;

        }




    }
}
