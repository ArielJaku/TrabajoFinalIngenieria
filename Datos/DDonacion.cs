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
    public class DDonacion
    {
        static string conexionstring = "server= DESKTOP-KASPEP1\\SQLEXPRESS; database= LibrosLibres3; integrated security=true";
        SqlConnection con = new SqlConnection(conexionstring);
        public int GenerarDonacion(Donacion oDonacion)
        {
            int flag = 0;
            //insertar imagen en base de datos
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "insert into donaciones(usuarioDonador, usuarioRecibidor, Libro, Fecha) values (@usuarioDonador, @usuarioRecibidor, @Libro, @Fecha)";
            cmd.Parameters.Add("@usuarioDonador", SqlDbType.Int).Value = oDonacion.DniDonador;
            cmd.Parameters.Add("@usuarioRecibidor", SqlDbType.Int).Value = oDonacion.DNIRecibidor;
            cmd.Parameters.Add("@Libro", SqlDbType.Int).Value = oDonacion.Libro;
            cmd.Parameters.Add("@Fecha", SqlDbType.Date).Value = DateTime.Today; ;
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con;
            con.Open();
            flag = cmd.ExecuteNonQuery();
            con.Close();

            return flag;
        }
        public int SumarReporteGenero(Donacion oDonacion)
        {
            int flag = 0;
            con.Open();
            string query = "update genero set rdonacion +=1 where id=(select genero from libros where id=" + oDonacion.Libro + ");";
            SqlCommand cmd = new SqlCommand(query, con);
            flag = cmd.ExecuteNonQuery();
            con.Close();
            return flag;

        }       
    }
}
