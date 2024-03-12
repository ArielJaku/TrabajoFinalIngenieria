using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Datos;
using Entidades;
using System.Data.SqlClient;

namespace Negocios
{
    public class Nusuario
    {
        DUsuario NU  = new DUsuario();
        

        public string frente;

        
        public DataTable TraerProvincias()
        {
           
            return NU.TraerProvincias();
        }


        public DataTable TraerLocalidades()
        {
            
            return NU.TraerLocalidades();
        }

        public DataTable TraerLocalidadesProvincia(Provincia oProvincia)
        {
            return NU.TraerLocalidadesProvincia(oProvincia);
        }

        public int CargarUsuario(int dni, string nom, string ape, string dir, int num, int loc, int pro, int rol)
        {
            
            return NU.CargarUsuario(dni,nom,ape,dir,num,loc,pro,rol);

        }

        public int RegistrarUsuario(int dni, string nom, string ape, string dir, int num, int loc, int pro, int rol, string Cor, string cont)
        {
            Seguridad oSeguridad = new Seguridad();
            Usuario oUsuario = new Usuario();
            oUsuario.DNI = dni;
            oUsuario.Nombre = nom;
            oUsuario.apellido = ape;
            oUsuario.direccion_calle = dir;
            oUsuario.direccion_numero = num;
            oUsuario.Idlocalidad = loc;
            oUsuario.Idprovincia = pro;
            oUsuario.permisos = rol;
            oUsuario.Correo = Cor;
            oSeguridad.DNIusuario = dni;
            oSeguridad.contraseña = cont;

            return NU.RegistrarUsuario(oUsuario, oSeguridad);

        }
        public int consultalogin(int Dni, string Contraseña)
        {

            return NU.consultalogin(Dni, Contraseña);

        }

        public int consultaRol(int Dni)
        {
           
            return NU.consultaRol(Dni);

        }
        public DataTable TraerUsuario(int dni)
        {

            return NU.TraerUsuario(dni);
        }

        public DataTable TraerLibrosUsuario(int dni)
        {
            return NU.TraerLibrosUsuario(dni);
        }

        public DataTable TraerUsuario2(int dni)
        {
          
            return NU.TraerUsuario2(dni);
        }
        public int cantidadUsuarios()
        {
            return NU.cantidadUsuarios();

        }
        public DataTable TraerUsuarios()
        {
            return NU.TraerUsuarios();
        }
        #region ABMUsuarios
        public DataTable TraerUsuarios2()
        {            
            return NU.TraerUsuarios2();
        }
        public DataTable TraerUsuarios2(Usuario oUsuario)
        {
            return NU.TraerUsuarios2(oUsuario);
        }
        public int AgregarUsuario(Usuario oUsuario,Seguridad oSeguridad)
        {
            return NU.AgregarUsuario(oUsuario, oSeguridad);

        }
        public DataTable TraerPermisos()
        {
            return NU.TraerPermisos();
        }
        public int BorrarUsuario(Usuario oUsuario)
        {
            return NU.BorrarUsuario(oUsuario);

        }
        public int ModificarUsuario(Usuario oUsuario, Seguridad oSeguridad)
        {
            return NU.ModificarUsuario(oUsuario, oSeguridad);

        }
        public int ModificarUsuario(Usuario oUsuario)
        {
            return NU.ModificarUsuario(oUsuario);

        }

        #endregion

        public int consultaExistencia(int Dni)
        {

            return NU.consultaExistencia(Dni);

        }

        public DataTable TraerAdquiridos(int Dni)
        {
            
            return NU.TraerAdquiridos(Dni);
        }
        public Usuario TienePrestamo(int Dni)
        {
            
            return NU.TienePrestamo(Dni);

        }
        public int ModificarSeguridad(Seguridad seg)
        {
            return NU.ModificarSeguridad(seg);
        }

        public Usuario DetalleUsuario(int Dni)
        {
            return NU.DetalleUsuario(Dni);
        }


    }
}
