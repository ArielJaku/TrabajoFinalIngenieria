using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Negocios;

namespace TRABAJO1
{
    public partial class PerfilMostar2 : System.Web.UI.Page
    {
        Nusuario VNU = new Nusuario();
        public int us;
        protected void Page_Load(object sender, EventArgs e)
        {
            us = Convert.ToInt32(Request.QueryString["valor"]);
            DataTable Datos = VNU.TraerUsuario2(us);
            lblmos.Text = Convert.ToString(Datos.Rows[0][1]);
            lblNomApe.Text = Convert.ToString(Datos.Rows[0][1]);
            lblCiud.Text = Convert.ToString(Datos.Rows[0][2]);
            lblProv.Text = Convert.ToString(Datos.Rows[0][3]);
            lblCorreo.Text = Convert.ToString(Datos.Rows[0][4]);
            GVlibrosc.DataSource = VNU.TraerLibrosUsuario(us);
            GVlibrosc.DataBind();
            GridView2.DataSource = VNU.TraerAdquiridos(us);
            GridView2.DataBind();


        }

        protected void GVlibrosc_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow fila = GVlibrosc.SelectedRow;
            string Lib = fila.Cells[1].Text;
            Response.Redirect("MostrarEjemplar.aspx?valor1=" + Lib + "&valor2=" + us);
            
        }
    }
}