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
    public class DPrestamo
    {
        static string conexionstring = "server= DESKTOP-KASPEP1\\SQLEXPRESS; database= LibrosLibres3; integrated security=true";
        SqlConnection con = new SqlConnection(conexionstring);
        Auditoria oAuditoria = new Auditoria();

        public int InsertarPrestamo(Prestamo oPrestamo)
        {   
            int flag = 0;
            //insertar imagen en base de datos
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "insert into prestamo(UsuPrestador, UsuRecibidor, FechaPrestamo, FechaDevolucion, Estado, id_libro) values (@UsuPrestador, @UsuRecibidor, @FechaPrestamo, @FechaDevolucion, @Estado, @id_libro)";
            cmd.Parameters.Add("@UsuPrestador", SqlDbType.Int).Value = oPrestamo.dniPrestador;
            cmd.Parameters.Add("@UsuRecibidor", SqlDbType.Int).Value = oPrestamo.dniRecibidor;
            cmd.Parameters.Add("@FechaPrestamo", SqlDbType.DateTime).Value = oPrestamo.FechaPrestamo;
            cmd.Parameters.Add("@FechaDevolucion", SqlDbType.DateTime).Value = oPrestamo.FechaDevolucion;
            cmd.Parameters.Add("@id_libro", SqlDbType.Int).Value = oPrestamo.libro;
            cmd.Parameters.Add("@Estado", SqlDbType.Int).Value = 1;
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con;
            con.Open();
            flag = cmd.ExecuteNonQuery();
            con.Close();
            return flag;

        }

        public DataTable ConsultarAutoresGV()
        {
            Autores oAutores = new Autores();
            return oAutores.ConsultarAutoresGV();

        }

        public int FinalizarPrestamo(Prestamo oPrestamo)
        {
            int flag = 0;
            con.Open();
            string query = "update prestamo set Estado=4 where id_libro = "+ oPrestamo.libro +" and UsuPrestador = " + oPrestamo.dniPrestador + ";" +
                           "update usuarios set TienePrestamo=0 where dni = (SELECT top 1 UsuRecibidor FROM Prestamo where UsuPrestador = "+ oPrestamo.dniPrestador +" and id_libro = " + oPrestamo.libro + " order by id desc );";
            SqlCommand cmd = new SqlCommand(query, con);
            flag = cmd.ExecuteNonQuery();
            con.Close();
            return flag;
        }

        public Prestamo TraerPrestamo(Usuario usuario)
        {
            //traer objeto con consulta a sql ejemplo para recordar y tener
            Prestamo pre = new Prestamo();
            string query = "select * from prestamo where UsuRecibidor = " + usuario.DNI + " order by id desc";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter data = new SqlDataAdapter(cmd);
            DataTable tabla = new DataTable();
            data.Fill(tabla);
            pre.id = Convert.ToInt32(tabla.Rows[0]["id"]);
            pre.dniPrestador = Convert.ToInt32(tabla.Rows[0]["UsuPrestador"]);
            pre.dniRecibidor = Convert.ToInt32(tabla.Rows[0]["UsuRecibidor"]);            
            pre.FechaPrestamo = Convert.ToDateTime(tabla.Rows[0]["FechaPrestamo"]);
            pre.FechaDevolucion = Convert.ToDateTime(tabla.Rows[0]["FechaDevolucion"]);
            pre.libro = Convert.ToInt32(tabla.Rows[0]["id_libro"]);
            if (Convert.ToInt32(tabla.Rows[0]["Estado"]) == 1)
            {
                Activo est = new Activo();
                pre.Estado = est;
            }
            if (Convert.ToInt32(tabla.Rows[0]["Estado"]) == 2)
            {
                PorVencer est = new PorVencer();
                pre.Estado = est;
            }
            if (Convert.ToInt32(tabla.Rows[0]["Estado"]) == 3)
            {
                Vencido est = new Vencido();
                pre.Estado = est;
            }
            if (Convert.ToInt32(tabla.Rows[0]["Estado"]) == 4)
            {
                Devuelto act = new Devuelto();
                pre.Estado = act;
            }
            return pre;
        }
        public int ActualizarPrestamoPorVencer(Prestamo oPrestamo)
        {
            int flag = 0;
            con.Open();
            string query = "update prestamo set Estado=2 where id_libro = " + oPrestamo.libro + " and UsuPrestador = " + oPrestamo.dniPrestador + ";";
            SqlCommand cmd = new SqlCommand(query, con);
            flag = cmd.ExecuteNonQuery();
            con.Close();
            return flag;
        }
        public int ActualizarPrestamoVencido(Prestamo oPrestamo)
        {
            int flag = 0;
            con.Open();
            string query = "update prestamo set Estado=3 where id_libro = " + oPrestamo.libro + " and UsuPrestador = " + oPrestamo.dniPrestador + ";";
            SqlCommand cmd = new SqlCommand(query, con);
            flag = cmd.ExecuteNonQuery();
            con.Close();
            return flag;
        }
    }
}
