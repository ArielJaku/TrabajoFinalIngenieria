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
    public class Dlibro
    {
        #region ADO.NET
        static string conexionstring = "server= DESKTOP-KASPEP1\\SQLEXPRESS; database= LibrosLibres3; integrated security=true";
        SqlConnection con = new SqlConnection(conexionstring);
        public int Insertarlibro(Libro oLibro)
        {
            int flag = 0;
            con.Open();
            string query = "insert into libros values (" + oLibro.isbn + ",'" + oLibro.nombre + "'," + oLibro.idAutor + ",0,11,0)";
            SqlCommand cmd = new SqlCommand(query, con);
            flag = cmd.ExecuteNonQuery();
            con.Close();
            return flag;

        }

        public DataTable ConsultarLibrosGV()
        {
            string query = "select l.nombre,l.id, isbn, a.nombre + ' ' + a.apellido as autor from libros as l join autores as a on l.autor = a.id";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter data = new SqlDataAdapter(cmd);
            DataTable tabla = new DataTable();
            data.Fill(tabla);
            return tabla;
        }

        public DataTable ConsultarLibrosGV1()
        {
            string query = "select * from libros";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter data = new SqlDataAdapter(cmd);
            DataTable tabla = new DataTable();
            data.Fill(tabla);
            return tabla;
        }

        public DataTable ConsultarLibrosGV1(Libro olibro)
        {
            string query = "select * from libros where nombre like '%" + olibro.nombre + "%';";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter data = new SqlDataAdapter(cmd);
            DataTable tabla = new DataTable();
            data.Fill(tabla);
            return tabla;
        }

        public DataTable ConsultarLibrosGV(Libro oLib)
        {
            string query = "select l.nombre,isbn, a.nombre + ' ' + a.apellido as autor from libros as l join autores as a on l.autor = a.id where l.nombre like '%"+ oLib.nombre + "%'"; 
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter data = new SqlDataAdapter(cmd);
            DataTable tabla = new DataTable();
            data.Fill(tabla);
            return tabla;
        }

        public DataTable TraerAutores()
        {
            string query = "select * from autores";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter data = new SqlDataAdapter(cmd);
            DataTable tabla = new DataTable();
            data.Fill(tabla);
            return tabla;
        }

        public DataTable TraerEditoriales()
        {
            string query = "select * from editoriales";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter data = new SqlDataAdapter(cmd);
            DataTable tabla = new DataTable();
            data.Fill(tabla);
            return tabla;
        }

        public int InsertarlibroUsuario(int isbn, string nom, int aut, int edi,int dni)
        {
            int flag = 0;
            con.Open();
            string query = "insert into libros values (" + isbn + ",'" + nom + "'," + aut + "," + edi + ",1) ; insert into ejemplares values((select id from libros where isbn= " + isbn + ")," + dni + ");";
            SqlCommand cmd = new SqlCommand(query, con);
            flag = cmd.ExecuteNonQuery();
            con.Close();
            return flag;

        }

        public int InsertarlibroUsuario(int isbn, int dni, int año)
        {
            int flag = 0;
            con.Open();
            string query = "insert into ejemplares values((select id from libros where isbn= " + isbn + ")," + dni + ");";
            SqlCommand cmd = new SqlCommand(query, con);
            flag = cmd.ExecuteNonQuery();
            con.Close();
            return flag;

        }

        public DataTable TraerMasBuscados()
        {
            string query = "select top 5 l.nombre, a.nombre + ' ' + a.apellido as autor from libros as l join autores as a on l.autor=a.id order by RBusqueda desc";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter data = new SqlDataAdapter(cmd);
            DataTable tabla = new DataTable();
            data.Fill(tabla);
            return tabla;
        }


        public DataTable TraerMasCargados()
        {
            string query = "select top 5 l.nombre, a.nombre + ' ' + a.apellido as autor from libros as l join autores as a on l.autor=a.id order by stock desc";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter data = new SqlDataAdapter(cmd);
            DataTable tabla = new DataTable();
            data.Fill(tabla);
            return tabla;
        }

        public DataTable TraerDuenos(Libro oLibro)
        {
            string query = "select u.dni,u.nombre,u.apellido,l.nombre,u.localidad from ejemplares as lc join libros as l on lc.id_libro = l.id join usuarios as u on lc.dni_usuario = u.dni where l.nombre ='" + oLibro.nombre + "' and estado = 1";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter data = new SqlDataAdapter(cmd);
            DataTable tabla = new DataTable();
            data.Fill(tabla);
            return tabla;
        }

        public int BorrarLibro(Libro oLibro)
        {
            try
            {
                int flag = 0;
                con.Open();
                string query = "delete from libros where id = " + oLibro.id;
                SqlCommand cmd = new SqlCommand(query, con);
                flag = cmd.ExecuteNonQuery();
                con.Close();
                return flag;

            }
            catch (Exception)
            {

                throw;
            }
            

        }
        public int ModificarLibro(Libro oLibro)
        {
            int flag = 0;
            con.Open();
            string query = "update libros set isbn="+ oLibro.isbn +", nombre='" + oLibro.nombre + "', autor=" + oLibro.idAutor + ",stock=" + oLibro.stock + ", genero=" + oLibro.idGenero + " where id=" + oLibro.id;
            SqlCommand cmd = new SqlCommand(query, con);
            flag = cmd.ExecuteNonQuery();
            con.Close();
            return flag;
        }

        public int CargarLibro(Libro oLibro)
        {
            int flag = 0;
            con.Open();
            string query = "insert into libros values (" + oLibro.isbn + ",'" + oLibro.nombre + "'," + oLibro.idAutor + "," + oLibro.stock + "," + oLibro.idGenero + ")";
            SqlCommand cmd = new SqlCommand(query, con);
            flag = cmd.ExecuteNonQuery();
            con.Close();
            return flag;

        }

        public int SumarReporteBusqueda(Libro oLibro)
        {
            int flag = 0;
            con.Open();
            string query = "update libros set RBusqueda +=1 where id=" + oLibro.id + ";";
            SqlCommand cmd = new SqlCommand(query, con);
            flag = cmd.ExecuteNonQuery();
            con.Close();
            return flag;

        }
        public int SumarReporteGenero(Libro oLibro)
        {
            int flag = 0;
            con.Open();
            string query = "update genero set rbusqueda +=1 where id=(select genero from libros where id="+ oLibro.id +");";
            SqlCommand cmd = new SqlCommand(query, con);
            flag = cmd.ExecuteNonQuery();
            con.Close();
            return flag;

        }
        public int cantidadLibros()
        {
            int count;
            con.Open();
            string Query = "select count(*) from libros";
            SqlCommand cmd = new SqlCommand(Query, con);
            count = Convert.ToInt32(cmd.ExecuteScalar());
            con.Close();
            return count;

        }

        #endregion





    }
}
