using Negocios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace TRABAJO1
{
    public partial class PorGeneros : System.Web.UI.Page
    {
        NGenero GeneroManager = new NGenero();
        protected void Page_Load(object sender, EventArgs e)
        {
           consultarGeneros();

        }

        public void consultarGeneros()
        {
            Repeater1.DataSource = GeneroManager.ConsultarGenerosGV();
            Repeater1.DataBind();
        }

        protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            var btn = (Button)sender;
            var item = (RepeaterItem)btn.NamingContainer;
            var ddl = (Label)item.FindControl("Label1");
            Response.Redirect("BuscarEjemplares.aspx?valor=" + ddl.Text);
        }

    }
}