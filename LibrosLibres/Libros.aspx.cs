using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocios;
using System.Data;
using Entidades;

namespace TRABAJO1
{
    public partial class Libros : Utilidad
    {
        Nlibro VNL = new Nlibro();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Request.QueryString["valor"]!=null)
            {
                txtBusqueda.Text = Request.QueryString["valor"].ToString();
                GVLista.DataSource = VNL.ConsultarLibrosGV(txtBusqueda.Text);
                GVLista.DataBind();
                

            }
            else
            {
                GVLista.DataSource = VNL.ConsultarLibrosGV();
                GVLista.DataBind();

            }

        }

        protected void btnBus_Click(object sender, EventArgs e)
        {
            GVLista.DataSource = VNL.ConsultarLibrosGV(txtBusqueda.Text);
            GVLista.DataBind();
        }

        protected void GVLista_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GVLista.PageIndex = e.NewPageIndex;
            VNL.ConsultarLibrosGV();
        }

        protected void GVDUENOS_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow fila = GVDUENOS.SelectedRow;

            int usu = Convert.ToInt32(fila.Cells[1].Text);
            Response.Redirect("PerfilMostar2.aspx?valor="+usu);
        }

        protected void GVLista_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(Session["Usuario"]!= null)
            {

                GridViewRow fila = GVLista.SelectedRow;
                
                Libro oLibro = new Libro();
                string Lib = fila.Cells[2].Text;
                oLibro.id = int.Parse(Lib);
                oLibro.nombre = fila.Cells[1].Text;
                VNL.SumarReporteBusqueda(oLibro);
                VNL.SumarReporteGenero(oLibro);
                GVDUENOS.DataSource = VNL.TraerDuenos(oLibro);
                GVDUENOS.DataBind();

            }
            else
            {
                GridViewRow fila = GVLista.SelectedRow;
                string Lib = fila.Cells[2].Text;
                Libro oLibro = new Libro();
                oLibro.id = int.Parse(Lib);
                VNL.SumarReporteBusqueda(oLibro);
                VNL.SumarReporteGenero(oLibro);
                MsgBox("Registrese o Inicie sesion para ver quien tiene este libro");
            }


        }
    }
}