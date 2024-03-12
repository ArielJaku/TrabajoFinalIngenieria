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
    public class DEntregas
    {
        static string conexionstring = "server= DESKTOP-KASPEP1\\SQLEXPRESS; database= LibrosLibres3; integrated security=true";
        SqlConnection con = new SqlConnection(conexionstring);
        public List<Entrega> listaDeEntregas()
        {
            List<Entrega> Lista = new List<Entrega>();
            string query = "select * from entregas as e join entregaDirecciones as d on e.id = d.idEntrega ";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter data = new SqlDataAdapter(cmd);
            DataTable tabla = new DataTable();
            data.Fill(tabla);
            foreach(DataRow dr in tabla.Rows)
            {
                Entrega ee = new Entrega();
                ee.Id = Convert.ToInt32(dr["id"]);
                ee.IdVenta = Convert.ToInt32(dr["idVenta"]);
                ee.UsuarioCadete = Convert.ToInt32(dr["usuarioCadete"]);
                ee.FechaInicio = Convert.ToDateTime(dr["fechaInicio"]);
                ee.EstadoEntrega = Convert.ToInt32(dr["estado"]);
                ee.DireccionEntregaInicio = Convert.ToString(dr["entregaDireccionBusqueda"]);
                ee.DireccionEntregaFin = Convert.ToString(dr["entregaDireccionEntrega"]);
                Lista.Add(ee);
            }

            return Lista;
        }

        public int EntregaNueva(Entrega oEntrega)
        {
            int flag = 0;
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "insert into entregas(idVenta, UsuarioCadete, fechaInicio, estado) values (@idVenta, @UsuarioCadete, @fechaInicio, @estado)";
            cmd.Parameters.Add("@idVenta", SqlDbType.Int).Value = oEntrega.IdVenta;
            cmd.Parameters.Add("@UsuarioCadete", SqlDbType.Int).Value = oEntrega.UsuarioCadete;
            cmd.Parameters.Add("@fechaInicio", SqlDbType.Date).Value = oEntrega.FechaInicio;
            cmd.Parameters.Add("@estado", SqlDbType.Int).Value = oEntrega.EstadoEntrega;
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con;
            con.Open();
            flag = cmd.ExecuteNonQuery();
            con.Close();
            return flag;
        }

        public int InsertarDirecciones(Entrega oEntrega)
        {
            int flag = 0;
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "insert into entregaDirecciones(idEntrega, entregaDireccionBusqueda, entregaDireccionEntrega) values (@idEntrega, @entregaDireccionBusqueda, @entregaDireccionEntrega)";
            cmd.Parameters.Add("@idEntrega", SqlDbType.Int).Value = oEntrega.Id;
            cmd.Parameters.Add("@entregaDireccionBusqueda", SqlDbType.NVarChar).Value = oEntrega.DireccionEntregaInicio;
            cmd.Parameters.Add("@entregaDireccionEntrega", SqlDbType.NVarChar).Value = oEntrega.DireccionEntregaFin;
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con;
            con.Open();
            flag = cmd.ExecuteNonQuery();
            con.Close();
            return flag;
        }

        public Entrega traerEntrega(int idEntrega)
        {
            Entrega oEntrega = new Entrega();
            string query = "select * from entregas as e join entregaDirecciones as d on e.id = d.idEntrega where e.id = " + idEntrega;
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter data = new SqlDataAdapter(cmd);
            DataTable tabla = new DataTable();
            data.Fill(tabla);
            oEntrega.Id = Convert.ToInt32(tabla.Rows[0]["id"]);
            oEntrega.IdVenta = Convert.ToInt32(tabla.Rows[0]["idVenta"]);
            oEntrega.UsuarioCadete = Convert.ToInt32(tabla.Rows[0]["usuarioCadete"]);
            oEntrega.FechaInicio = Convert.ToDateTime(tabla.Rows[0]["fechaInicio"]);
            oEntrega.EstadoEntrega = Convert.ToInt32(tabla.Rows[0]["estado"]);
            oEntrega.DireccionEntregaInicio = Convert.ToString(tabla.Rows[0]["entregaDireccionBusqueda"]);
            oEntrega.DireccionEntregaFin = Convert.ToString(tabla.Rows[0]["entregaDireccionEntrega"]);
            return oEntrega;
        }

        public int cambiarEstadoEntrega(int idEntrega)
        {
            int flag = 0;
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "update entregas set estado = estado + 1 where id ="+ idEntrega;
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con;
            con.Open();
            flag = cmd.ExecuteNonQuery();
            con.Close();
            return flag;
        }

        public Entrega traerUltimaEntrega()
        {
            Entrega oEntrega = new Entrega();
            string query = "select * from entregas order by id desc";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter data = new SqlDataAdapter(cmd);
            DataTable tabla = new DataTable();
            data.Fill(tabla);
            oEntrega.Id = Convert.ToInt32(tabla.Rows[0]["id"]);
            oEntrega.IdVenta = Convert.ToInt32(tabla.Rows[0]["idVenta"]);
            oEntrega.UsuarioCadete = Convert.ToInt32(tabla.Rows[0]["usuarioCadete"]);
            oEntrega.FechaInicio = Convert.ToDateTime(tabla.Rows[0]["fechaInicio"]);
            oEntrega.EstadoEntrega = Convert.ToInt32(tabla.Rows[0]["estado"]);
            return oEntrega;

        }

        public List<Entrega> listaDeEntregasPendientes(int dni)
        {
            List<Entrega> Lista = new List<Entrega>();
            string query = "select * from entregas join venta on idVenta = venta.id where estado = 3 and dniComprador = " + dni;
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter data = new SqlDataAdapter(cmd);
            DataTable tabla = new DataTable();
            data.Fill(tabla);
            foreach (DataRow dr in tabla.Rows)
            {
                Entrega ee = new Entrega();
                ee.Id = Convert.ToInt32(dr["id"]);
                ee.IdVenta = Convert.ToInt32(dr["idVenta"]);
                ee.UsuarioCadete = Convert.ToInt32(dr["usuarioCadete"]);
                ee.FechaInicio = Convert.ToDateTime(dr["fechaInicio"]);
                ee.EstadoEntrega = Convert.ToInt32(dr["estado"]);
                Lista.Add(ee);
            }

            return Lista;

        }
    }
}
