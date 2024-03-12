using Negocios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TRABAJO1
{
    public partial class BuscarEjemplares : Utilidad
    {
        Nejemplar EjemplarManager = new Nejemplar();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["valor"] != null)
            {
                busquedaEjemplar.Text = Request.QueryString["valor"].ToString();
                rbPorGenero.Checked = true;
                var busqueda = busquedaEjemplar.Text;
                Repeater1.DataSource = EjemplarManager.BuscarPorGenero(busqueda);
                Repeater1.DataBind();

            }
            else
            {
                consultarEjemplares();
            }
                
        }
        public void consultarEjemplares()
        {
            Repeater1.DataSource = EjemplarManager.TraerEjemplares();
            Repeater1.DataBind();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            RepeaterItem item = (RepeaterItem) btn.NamingContainer;            
            Label id_lib = (Label)item.FindControl("lblIDLIB");
            Label dni = (Label)item.FindControl("lblDNI");
            int DNI = Convert.ToInt32(dni.Text);
            int IDLIB = Convert.ToInt32(id_lib.Text); ;
            Response.Redirect("MostrarEjemplar.aspx?valor1=" + IDLIB + "&valor2=" + DNI);
        }

        protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {

        }

        protected void ButtonBuscar_Click(object sender, EventArgs e)
        {
            if(rbPorLibro.Checked)
            {
                var busqueda = busquedaEjemplar.Text;
                Repeater1.DataSource = EjemplarManager.BuscarPorNombre(busqueda);
                Repeater1.DataBind();
            }else if (rbPorGenero.Checked)
            {
                var busqueda = busquedaEjemplar.Text;
                Repeater1.DataSource = EjemplarManager.BuscarPorGenero(busqueda);
                Repeater1.DataBind();
            }else if (rbPorEscritor.Checked)
            {
                var busqueda = busquedaEjemplar.Text;
                Repeater1.DataSource = EjemplarManager.BuscarPorEscritor(busqueda);
                Repeater1.DataBind();
            }
            else
            {
                MsgBox("POR DEFECTO SE BUSCARA POR NOMBRE");
                var busqueda = busquedaEjemplar.Text;
                Repeater1.DataSource = EjemplarManager.BuscarPorNombre(busqueda);
                Repeater1.DataBind();
            }

        }
    }
}