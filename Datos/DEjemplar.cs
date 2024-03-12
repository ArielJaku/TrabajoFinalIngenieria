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
    public class DEjemplar
    {
        static string conexionstring = "server= DESKTOP-KASPEP1\\SQLEXPRESS; database= LibrosLibres3; integrated security=true";
        SqlConnection con = new SqlConnection(conexionstring);

        public int InsertarEjemplar(int isbn, int dni, Ejemplares oEjem)
        {
            int flag = 0;
            con.Open();
            string query = "insert into ejemplares values((select id from libros where isbn= " + isbn + ")," + dni + ", " + oEjem.año + " , ' " + oEjem.imagen1 + " ' , ' "+ oEjem.imagen2 + " '," + oEjem.Ideditorial + ");";
            SqlCommand cmd = new SqlCommand(query, con);
            flag = cmd.ExecuteNonQuery();
            con.Close();
            return flag;

        }
        public DataTable TraerEjemplar(int dni, int idLibro)
        {
            string query = "select l.nombre,a.nombre+' '+a.apellido,ed.editorial,e.año,lo.localidad,e.imagen1,e.imagen2 from ejemplares as e join libros as l on" + 
            " e.id_libro = l.id join usuarios as u on u.dni = e.dni_usuario join autores as a on"+
            " a.id = l.autor join editoriales as ed on e.id_editorial = ed.id"+
            " join localidades as lo on u.localidad = lo.cp"+
            " where e.dni_usuario = " + dni +
            " and e.id_libro = "+ idLibro +";";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter data = new SqlDataAdapter(cmd);
            DataTable tabla = new DataTable();
            data.Fill(tabla);
            return tabla;
        }

        public int InsertarEjemplar2(int id, int dni, Ejemplares oEjem)
        {
            try
            {
                int flag = 0;
                //insertar imagen en base de datos
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "insert into ejemplares(id_libro, dni_usuario, año, imagen1, imagen2, id_editorial, estado, precio) values (@idlibro,@dniusuario,@año,@imagen1,@imagen2,@id_editorial,@estado, @precio)";
                cmd.Parameters.Add("@idlibro", SqlDbType.Int).Value = id;
                cmd.Parameters.Add("@dniusuario", SqlDbType.Int).Value = dni;
                cmd.Parameters.Add("@año", SqlDbType.Int).Value = oEjem.año;
                cmd.Parameters.Add("@imagen1", SqlDbType.Image).Value = oEjem.imagen1;
                cmd.Parameters.Add("@imagen2", SqlDbType.Image).Value = oEjem.imagen2;
                cmd.Parameters.Add("@id_editorial", SqlDbType.Int).Value = oEjem.Ideditorial;
                cmd.Parameters.Add("@estado", SqlDbType.Int).Value = 1;
                cmd.Parameters.Add("@precio", SqlDbType.Decimal).Value = oEjem.precio;
                cmd.CommandType = CommandType.Text;
                cmd.Connection = con;
                con.Open();
                flag = cmd.ExecuteNonQuery();
                con.Close();

                return flag;
            }
            catch (Exception ex)
            {

                throw ex;
            }
           
        }
        public int cantidadEjemplares()
        {
            int count;
            con.Open();
            string Query = "select count(*) from ejemplares";
            SqlCommand cmd = new SqlCommand(Query, con);
            count = Convert.ToInt32(cmd.ExecuteScalar());
            con.Close();
            return count;

        }
        public int ModificarEstadoEjemplar(Ejemplares oEjemplar)
        {
            int flag = 0;
            con.Open();
            string query = "update ejemplares set estado=" + oEjemplar.estado + " where id_libro=" + oEjemplar.id_libro + " and dni_usuario= " + oEjemplar.id_usuario + ";";
            SqlCommand cmd = new SqlCommand(query, con);
            flag = cmd.ExecuteNonQuery();
            con.Close();
            return flag;
        }
        public int SumarStockLibro(Libro oLibro)
        {
            int flag = 0;
            con.Open();
            string query = "update genero set rbusqueda +=1 where id=(select genero from libros where id=" + oLibro.id + ");";
            SqlCommand cmd = new SqlCommand(query, con);
            flag = cmd.ExecuteNonQuery();
            con.Close();
            return flag;

        }
        public int SumarReporteGenero(Ejemplares oEjemplar)
        {
            int flag = 0;
            con.Open();
            string query = "update genero set rcargas +=1 where id=(select genero from libros where id=" + oEjemplar.id_libro + ");";
            SqlCommand cmd = new SqlCommand(query, con);
            flag = cmd.ExecuteNonQuery();
            con.Close();
            return flag;

        }
        public int SumarStockLibro(Ejemplares oEjemplar)
        {
            int flag = 0;
            con.Open();
            string query = "update libros set stock +=1 where id="+ oEjemplar.id_libro +";";
            SqlCommand cmd = new SqlCommand(query, con);
            flag = cmd.ExecuteNonQuery();
            con.Close();
            return flag;

        }

        public DataTable TraerEjemplares()
        {
            string query = "select imagen1 , precio, id_libro, dni_usuario, usuarios.nombre , apellido, libros.nombre from ejemplares join usuarios on ejemplares.dni_usuario = usuarios.dni join libros on ejemplares.id_libro = libros.id where ejemplares.estado != 5";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter data = new SqlDataAdapter(cmd);
            DataTable tabla = new DataTable();
            data.Fill(tabla);
            return tabla;
        }

        public DataTable BuscarPorNombre(string Nombre)
        {
            string query = "select imagen1 , precio, id_libro, dni_usuario, usuarios.nombre , apellido, libros.nombre from ejemplares join usuarios on ejemplares.dni_usuario = usuarios.dni join libros on ejemplares.id_libro = libros.id where libros.nombre like '%"+ Nombre +"%'";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter data = new SqlDataAdapter(cmd);
            DataTable tabla = new DataTable();
            data.Fill(tabla);
            return tabla;
        }

        public DataTable BuscarPorGenero(string Genero)
        {
            string query = "select imagen1 , precio, id_libro, dni_usuario, usuarios.nombre , apellido, libros.nombre from ejemplares join usuarios on ejemplares.dni_usuario = usuarios.dni join libros on ejemplares.id_libro = libros.id join genero on libros.genero = genero.id where genero.genero like '%" + Genero + "%'";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter data = new SqlDataAdapter(cmd);
            DataTable tabla = new DataTable();
            data.Fill(tabla);
            return tabla;
        }

        public DataTable BuscarPorEscritor(string Escritor)
        {
            string query = "select imagen1 , precio, id_libro, dni_usuario, usuarios.nombre , usuarios.apellido, libros.nombre from ejemplares join usuarios on ejemplares.dni_usuario = usuarios.dni join libros on ejemplares.id_libro = libros.id join autores on libros.autor = autores.id where concat(autores.nombre,autores.apellido) like '%"+ Escritor +"%'";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter data = new SqlDataAdapter(cmd);
            DataTable tabla = new DataTable();
            data.Fill(tabla);
            return tabla;
        }


    }
}
