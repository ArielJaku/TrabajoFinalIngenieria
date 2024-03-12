using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;
using System.Data;

namespace Negocios
{
    public class ConexionSQLN
    {
        ConexionSQL cn = new ConexionSQL();

        #region USUARIOS
        public int conSQL(string user, string pass)
        {
            return cn.consultalogin(user, pass);

        }
        #endregion

        #region LIBROS  

        public DataTable ConMasBuscados()
        {
            return cn.ConsultarMasBuscados();
        }

        public DataTable ConMasCargados()
        {
            return cn.ConsultarMasCargados();
        }

        #endregion
    }
}
