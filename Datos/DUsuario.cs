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
    public class DUsuario
    {
        static string conexionstring = "server= DESKTOP-KASPEP1\\SQLEXPRESS; database= LibrosLibres3; integrated security=true";
        SqlConnection con = new SqlConnection(conexionstring);

        public DataTable TraerProvincias()
        {
            string query = "select * from provincias";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter data = new SqlDataAdapter(cmd);
            DataTable tabla = new DataTable();
            data.Fill(tabla);
            return tabla;
        }


        public DataTable TraerLocalidades()
        {
            string query = "select * from localidades";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter data = new SqlDataAdapter(cmd);
            DataTable tabla = new DataTable();
            data.Fill(tabla);
            return tabla;
        }
        public DataTable TraerLocalidadesProvincia(Provincia oProvincia)
        {
            string query = "select * from localidades where provincia = " + oProvincia.id + ";";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter data = new SqlDataAdapter(cmd);
            DataTable tabla = new DataTable();
            data.Fill(tabla);
            return tabla;
        }

        public int CargarUsuario(int dni, string nom,string ape,string dir, int num,int loc, int pro,int rol)
        {
            int flag = 0;
            con.Open();
            string query = "insert into usuarios values (" + dni + ",'" + nom + "','" + ape + "','"+ dir +"',"+ num +","+ loc +"," + pro +",2)";
            SqlCommand cmd = new SqlCommand(query, con);
            flag = cmd.ExecuteNonQuery();
            con.Close();
            return flag;

        }

        public int RegistrarUsuario(Usuario oUsuario, Seguridad oSeguridad)
        {
            
            int flag = 0;
            con.Open();
            string query = "insert into usuarios values (" + oUsuario.DNI + ",'" + oUsuario.Nombre + "','" + oUsuario.apellido + "','" + oUsuario.direccion_calle + "'," + oUsuario.direccion_numero + "," + oUsuario.Idlocalidad + "," + oUsuario.Idprovincia + ",2,'"+ oUsuario.Correo +"', 0); insert into seguridad values("+ oSeguridad.DNIusuario +",'"+ oSeguridad.contraseña +"',2)";
            SqlCommand cmd = new SqlCommand(query, con);
            flag = cmd.ExecuteNonQuery();
            con.Close();
            return flag;

        }
        #region Seguridad

        public int consultalogin(int Dni, string Contraseña)
        {
            int count;
            con.Open();
            string Query = "select count(*) from seguridad where dni_usuario = " + Dni + " and contraseña = '" + Contraseña + "'";
            SqlCommand cmd = new SqlCommand(Query, con);
            count = Convert.ToInt32(cmd.ExecuteScalar());
            con.Close();
            return count;

        }
        public int consultaRol(int Dni)
        {
            int count;
            con.Open();
            string Query = "select rol from seguridad where dni_usuario = " + Dni + ";";
            SqlCommand cmd = new SqlCommand(Query, con);
            count = Convert.ToInt32(cmd.ExecuteScalar());
            con.Close();
            return count;

        }

        public DataTable TraerUsuario(int dni)
        {
            string query = "select * from usuarios where dni = " + dni + ";";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter data = new SqlDataAdapter(cmd);
            DataTable tabla = new DataTable();
            data.Fill(tabla);
            return tabla;
        }

        public DataTable TraerLibrosUsuario(int dni)
        {
            string query = "select id_libro, l.nombre, a.nombre + ' ' + a.apellido as autor, es.estado from ejemplares as lc join libros as l on id_libro = l.id join autores as a on l.autor = a.id join estados as es on lc.estado = es.id where dni_usuario = " + dni +" ; ";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter data = new SqlDataAdapter(cmd);
            DataTable tabla = new DataTable();
            data.Fill(tabla);
            return tabla;
        }

        public DataTable TraerUsuario2(int dni)
        {
            string query = "select dni,nombre + ' ' + apellido,l.localidad,p.provincia,correo from usuarios as u join localidades as l on u.localidad = l.cp join provincias as p on u.provincia = p.id where dni = "+ dni +";";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter data = new SqlDataAdapter(cmd);
            DataTable tabla = new DataTable();
            data.Fill(tabla);
            return tabla;
        }
        public int cantidadUsuarios()
        {
            int count;
            con.Open();
            string Query = "select count(*) from usuarios";
            SqlCommand cmd = new SqlCommand(Query, con);
            count = Convert.ToInt32(cmd.ExecuteScalar());
            con.Close();
            return count;

        }

        public DataTable TraerUsuarios()
        {
            string query = "select dni, nombre + ' ' + apellido as nombre from usuarios";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter data = new SqlDataAdapter(cmd);
            DataTable tabla = new DataTable();
            data.Fill(tabla);
            return tabla;
        }

        #endregion
        #region ABMUsuarios
        public DataTable TraerUsuarios2()
        {
            string query = "select * from usuarios";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter data = new SqlDataAdapter(cmd);
            DataTable tabla = new DataTable();
            data.Fill(tabla);
            return tabla;
        }
        public DataTable TraerUsuarios2(Usuario oUsuario)
        {
            string query = "select * from usuarios where nombre like '%" + oUsuario.Nombre + "%';";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter data = new SqlDataAdapter(cmd);
            DataTable tabla = new DataTable();
            data.Fill(tabla);
            return tabla;
        }
        public int AgregarUsuario(Usuario oUsuario, Seguridad oSeguridad)
        {
            int flag = 0;
            con.Open();
            string query = "insert into usuarios values (" + oUsuario.DNI + ",'" + oUsuario.Nombre + "','" + oUsuario.apellido + "','" + oUsuario.direccion_calle + "'," + oUsuario.direccion_numero + "," + oUsuario.Idlocalidad + "," + oUsuario.Idprovincia + "," + oUsuario.permisos + ",'" + oUsuario.Correo + "')insert into usuarios values (" + oUsuario.DNI + ",'" + oUsuario.Nombre + "','" + oUsuario.apellido + "','" + oUsuario.direccion_calle + "'," + oUsuario.direccion_numero + "," + oUsuario.Idlocalidad + "," + oUsuario.Idprovincia + ",2,'" + oUsuario.Correo + "'); insert into seguridad values(" + oSeguridad.DNIusuario + ",'" + oSeguridad.contraseña + "',"+ oSeguridad.IDroles +");";
            SqlCommand cmd = new SqlCommand(query, con);
            flag = cmd.ExecuteNonQuery();
            con.Close();
            return flag;

        }
        public DataTable TraerPermisos()
        {
            string query = "select * from roles;";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter data = new SqlDataAdapter(cmd);
            DataTable tabla = new DataTable();
            data.Fill(tabla);
            return tabla;
        }
        public int BorrarUsuario(Usuario oUsuario)
        {
            int flag = 0;
            con.Open();
            string query = "delete from usuarios where dni = " + oUsuario.DNI;
            SqlCommand cmd = new SqlCommand(query, con);
            flag = cmd.ExecuteNonQuery();
            con.Close();
            return flag;

        }
        public int ModificarUsuario(Usuario oUsuario, Seguridad oSeguridad)
        {
            int flag = 0;
            con.Open();
            string query = "update usuarios set nombre ='" + oUsuario.Nombre +
                            "',apellido= '" + oUsuario.apellido +
                            "',direccion_calle='" + oUsuario.direccion_calle +
                            "',direccion_numero=" + oUsuario.direccion_numero +
                            ",localidad= " + oUsuario.Idlocalidad +
                            ",provincia= " + oUsuario.Idprovincia +
                            ",rol=" + oUsuario.permisos +
                            ",Correo='" + oUsuario.Correo +
                            "' where dni = " + oUsuario.DNI +
                            ";update seguridad set dni_usuario= " + oSeguridad.DNIusuario +
                            ",contraseña='" + oSeguridad.contraseña +
                            "',rol=" + oSeguridad.IDroles +
                            " where dni_usuario="+ oUsuario.DNI +";";
            SqlCommand cmd = new SqlCommand(query, con);
            flag = cmd.ExecuteNonQuery();
            con.Close();
            return flag;
        }
        public int ModificarUsuario(Usuario oUsuario)
        {
            int flag = 0;
            con.Open();
            string query = "update usuarios set nombre ='" + oUsuario.Nombre +
                            "',apellido= '" + oUsuario.apellido +
                            "',direccion_calle='" + oUsuario.direccion_calle +
                            "',direccion_numero=" + oUsuario.direccion_numero +
                            ",localidad= " + oUsuario.Idlocalidad +
                            ",provincia= " + oUsuario.Idprovincia +                            
                            ",Correo='" + oUsuario.Correo +
                            "' where dni = " + oUsuario.DNI + ";";            
            SqlCommand cmd = new SqlCommand(query, con);
            flag = cmd.ExecuteNonQuery();
            con.Close();
            return flag;
        }

        public int TienePrestamo(Usuario oUsuario)
        {
            int flag = 0;
            con.Open();
            string query = "update usuarios set tienePrestamo =" + oUsuario.TienePrestamo +                            
                            " where dni = " + oUsuario.DNI + ";";
            SqlCommand cmd = new SqlCommand(query, con);
            flag = cmd.ExecuteNonQuery();
            con.Close();
            return flag;
        }
        #endregion
        public int consultaExistencia(int Dni)
        {
            int count;
            con.Open();
            string Query = "select count(*) from usuarios where dni = " + Dni + ";";
            SqlCommand cmd = new SqlCommand(Query, con);
            count = Convert.ToInt32(cmd.ExecuteScalar());
            con.Close();
            return count;

        }

        public DataTable TraerAdquiridos(int Dni)
        {
            string query = "select d.usuarioDonador, d.usuarioRecibidor, l.nombre, d.fecha from donaciones as d join libros as l on d.Libro = l.id where d.usuarioRecibidor = " + Dni + ";";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter data = new SqlDataAdapter(cmd);
            DataTable tabla = new DataTable();
            data.Fill(tabla);
            return tabla;
        }

        public Usuario TienePrestamo(int Dni)
        {
            //traer objeto con consulta a sql ejemplo para recordar y tener
            Usuario usu = new Usuario();
            string query = "Select * from usuarios where dni = " + Dni + ";";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter data = new SqlDataAdapter(cmd);
            DataTable tabla = new DataTable();
            data.Fill(tabla);
            usu.DNI = Convert.ToInt32(tabla.Rows[0]["dni"]);
            usu.Nombre = Convert.ToString(tabla.Rows[0]["nombre"]);
            usu.apellido = Convert.ToString(tabla.Rows[0]["apellido"]);
            usu.permisos = Convert.ToInt32(tabla.Rows[0]["rol"]);
            usu.TienePrestamo = Convert.ToInt32(tabla.Rows[0]["TienePrestamo"]);
            return usu;
        }
        public int ModificarSeguridad(Seguridad seg)
        {
            int flag = 0;
            con.Open();
            string query = "update seguridad set contraseña = '" + seg.contraseña + "' where dni_usuario = " + seg.DNIusuario + ";";
            SqlCommand cmd = new SqlCommand(query, con);
            flag = cmd.ExecuteNonQuery();
            con.Close();
            return flag;
        }

        public Usuario DetalleUsuario(int Dni)
        {
            //traer objeto con consulta a sql ejemplo para recordar y tener
            Usuario usu = new Usuario();
            string query = "Select * from usuarios where dni = " + Dni + ";";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter data = new SqlDataAdapter(cmd);
            DataTable tabla = new DataTable();
            data.Fill(tabla);
            usu.DNI = Convert.ToInt32(tabla.Rows[0]["dni"]);
            usu.Nombre = Convert.ToString(tabla.Rows[0]["nombre"]);
            usu.apellido = Convert.ToString(tabla.Rows[0]["apellido"]);
            usu.permisos = Convert.ToInt32(tabla.Rows[0]["rol"]);
            usu.TienePrestamo = Convert.ToInt32(tabla.Rows[0]["TienePrestamo"]);
            usu.direccion_calle = Convert.ToString(tabla.Rows[0]["direccion_calle"]);
            usu.direccion_numero = Convert.ToInt32(tabla.Rows[0]["direccion_numero"]);
            return usu;
        }

    }
}
