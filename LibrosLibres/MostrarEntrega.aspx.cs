using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection.Emit;
using System.Security.Principal;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TRABAJO1
{
    public partial class MostrarEntrega : Utilidad
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            MsgBox("estoy entrando al load dela pagina");
            var idEntrega = Request.QueryString["valor"].ToString();
            Textito.Text = idEntrega;
            MsgBox(idEntrega);
        }
    }
}