using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocios;


namespace TRABAJO1
{
    
    public partial class Reportes : System.Web.UI.Page
    {    
        Nlibro oNL = new Nlibro();
        Nusuario oNU = new Nusuario();
        Nejemplar oNE = new Nejemplar();
        protected void Page_Load(object sender, EventArgs e)
        {
            Label1.Text = oNU.cantidadUsuarios().ToString();
            Label2.Text = oNE.cantidadEjemplares().ToString();
            Label3.Text = oNL.cantidadLibros().ToString();

        }
    }
}