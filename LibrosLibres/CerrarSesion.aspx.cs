using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades;

namespace TRABAJO1
{
    public partial class CerrarSesion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Auditoria oAuditoria = new Auditoria();
            int DNI = Convert.ToInt32(Session["Usuario"]);
            oAuditoria.LogSession(DNI, "El usuario cerro Sesion");
            Session["Usuario"] = null;
            Session["Id"] = null;
            Response.Redirect("Default.aspx");

        }
    }
}