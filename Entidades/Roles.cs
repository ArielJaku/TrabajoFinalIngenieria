using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Entidades
{
    public class Roles
    {
        /*Permiso oPermiso = new Permiso("id1");
        Rol oRoles = new Rol("Administrador");
        oRoles.add = new Permiso("id1");*/
        public int id { get; set; }

        public string nombre { get; set; }

        /*public int Seguridad() {
            int nro;
            nro = 0;
            return nro;
        }*/

        #region PERMISOS

        public bool Seguridad(int IdPag, int dniUsuario)
        {

            return true;
        }
          


        #endregion
    }
}
