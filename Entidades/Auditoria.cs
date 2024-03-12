using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Auditoria
    {
        static string conexionstring = "server= DESKTOP-KASPEP1\\SQLEXPRESS; database= LibrosLibres3; integrated security=true";
        SqlConnection con = new SqlConnection(conexionstring);
        public int LogSession(int dni, string accion)
        {
            int flag = 0;
            //insertar imagen en base de datos
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "insert into logSession(usuario, accion, Fecha) values (@usuario, @accion, GETDATE())";
            cmd.Parameters.Add("@usuario", SqlDbType.Int).Value = dni;
            cmd.Parameters.Add("@accion", SqlDbType.VarChar).Value = accion;            
            //cmd.Parameters.Add("@Fecha", SqlDbType.Date).Value = DateTime.Today; ;
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con;
            con.Open();
            flag = cmd.ExecuteNonQuery();
            con.Close();
            return flag;

        }

        public int LogAccion(int dni, string accion)
        {
            int flag = 0;
            //insertar imagen en base de datos
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "insert into logAccion(usuario, accion, Fecha) values (@usuario, @accion, GETDATE())";
            cmd.Parameters.Add("@usuario", SqlDbType.Int).Value = dni;
            cmd.Parameters.Add("@accion", SqlDbType.VarChar).Value = accion;
            //cmd.Parameters.Add("@Fecha", SqlDbType.Date).Value = DateTime.Today; ;
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con;
            con.Open();
            flag = cmd.ExecuteNonQuery();
            con.Close();

            return flag;

        }



    }
}
