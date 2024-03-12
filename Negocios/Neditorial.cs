using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using Datos;
using System.Data;

namespace Negocios
{
    public class Neditorial
    {
        DEditorial NDeditorial = new DEditorial();
        public int InsertarEditorial(Editorial oEditorial)
        {
          return NDeditorial.InsertarEditorial(oEditorial);

        }
        public int ModificarEditorial(Editorial oEditorial)
        {
           
            return NDeditorial.ModificarEditorial(oEditorial);

        }
        public int BorrarEditorial(Editorial oEditorial)
        {
          
            return NDeditorial.BorrarEditorial(oEditorial);

        }
        public DataTable ConsultarEditorialesGV()
        {
            
            return NDeditorial.ConsultarEditorialesGV();

        }

        public DataTable ConsultarEditorialGV(Editorial oEditorial)
        {
            return NDeditorial.ConsultarEditorialGV(oEditorial);
        }
    }
}
