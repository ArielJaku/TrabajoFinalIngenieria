using Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class DVenta
    {
        static string conexionstring = "server= DESKTOP-KASPEP1\\SQLEXPRESS; database= LibrosLibres3; integrated security=true";
        SqlConnection con = new SqlConnection(conexionstring);
        public int ingresarVenta(Venta oVenta, Usuario oUsuario)
        {        
            int flag = 0;            
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "insert into venta(dniComprador, dniVendedor, fechaVenta, idLibro, estadoVenta) values (@dniComprador, @dniVendedor, @fechaVenta, @idLibro, @estadoVenta)";
            cmd.Parameters.Add("@dniComprador", SqlDbType.Int).Value = oUsuario.DNI;
            cmd.Parameters.Add("@dniVendedor", SqlDbType.Int).Value = oVenta.dniVendedor;
            cmd.Parameters.Add("@fechaVenta", SqlDbType.Date).Value = oVenta.fechaVenta;
            cmd.Parameters.Add("@idLibro", SqlDbType.Int).Value = oVenta.idLibro;
            cmd.Parameters.Add("@estadoVenta", SqlDbType.Int).Value = oVenta.estadoVenta;
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con;
            con.Open();
            flag = cmd.ExecuteNonQuery();
            con.Close();
            return flag;


        }

        public Venta traerVenta(Venta oVenta)
        {
            //traer objeto con consulta a sql ejemplo para recordar y tener
            Venta ven = new Venta();
            string query = "Select * from venta where dniComprador = " + oVenta.dniComprador + "AND dniVendedor = " + oVenta.dniVendedor + " AND idLibro = " + oVenta.idLibro +";";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter data = new SqlDataAdapter(cmd);
            DataTable tabla = new DataTable();
            data.Fill(tabla);
            ven.id = Convert.ToInt32(tabla.Rows[0]["id"]);
            ven.dniComprador = Convert.ToInt32(tabla.Rows[0]["dniComprador"]);
            ven.dniVendedor = Convert.ToInt32(tabla.Rows[0]["dniVendedor"]);
            ven.fechaVenta = Convert.ToDateTime(tabla.Rows[0]["fechaVenta"]);
            ven.idLibro = Convert.ToInt32(tabla.Rows[0]["idLibro"]);
            ven.estadoVenta = Convert.ToInt32(tabla.Rows[0]["estadoVenta"]);
            return ven;
        }

    }
}
