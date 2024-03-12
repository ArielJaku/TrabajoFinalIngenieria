using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades;
using Microsoft.Ajax.Utilities;
using Negocios;


namespace TRABAJO1
{
    public partial class _Default : Utilidad
    {
        Nlibro VNL = new Nlibro();
        Nusuario VNU = new Nusuario();
        Entrega entregaParaConfirmar = new Entrega();
        protected void Page_Load(object sender, EventArgs e)
        {
            //GVBuscados.DataSource = VNL.TraerMasBuscados();
            //GVBuscados.DataBind();
            //GVCargados.DataSource = VNL.TraerMasCargados();
            //GVCargados.DataBind();
            if (Session["Usuario"] != null)
            {
                Usuario usu = new Usuario();
                usu = VNU.TienePrestamo(Convert.ToInt32(Session["Usuario"]));
                NEntrega Ce = new NEntrega();
                List<Entrega> ListaDeEntregasPendientes = new List<Entrega>();
                ListaDeEntregasPendientes = Ce.listaDeEntregasPendientes(Convert.ToInt32(Session["Usuario"]));
                if(ListaDeEntregasPendientes.Count > 0)
                {
                    foreach (var entrega in ListaDeEntregasPendientes) 
                    {
                        entregaParaConfirmar = entrega;
                        abrirModalConfirmacion();
                    }
                    
                }
                if (usu.TienePrestamo == 1)
                {
                    NPrestamo VNU = new NPrestamo();
                    Prestamo pre = new Prestamo();
                    pre = VNU.TraerPrestamo(usu);
                    pre.Estado.ControlarEstado(pre);
                    if(pre.Estado.Describir() == "PorVencer")
                    {
                        VNU.ActualizarPrestamoPorVencer(pre);
                        MsgBox("SU PRESTAMO ESTA CERCA DE VENCERSE POR FAVOR RECUERDE DE DEVOLVERLO A TIEMPO!!!");
                        
                    }
                    if (pre.Estado.Describir() == "Vencido")
                    {
                        VNU.ActualizarPrestamoVencido(pre);
                        MsgBox("USTED TIENE UN PRESTAMO VENCIDO . DEVUELVALO!!");
                    }
                    //pre.Estado.Describir();

                }

            }
            if (Session["Id"] != null)
            {
                if (Session["Id"].ToString() == "3")
                {
                    NEntrega Ce = new NEntrega();
                    Normal.Style["Display"] = "none";
                    RolCadete.Style["Visibility"] = "visible";
                    List<Entrega> ListaDeEntregas = new List<Entrega>();
                    ListaDeEntregas = Ce.listaDeEntregas();
                    RepeaterRepar.DataSource = ListaDeEntregas;
                    RepeaterRepar.DataBind();

                }
            }

        }

        protected void GVCargados_SelectedIndexChanged(object sender, EventArgs e)
        {
            //GridViewRow fila = GVCargados.SelectedRow;

            //string Lib = fila.Cells[1].Text;
            //Response.Redirect("Libros.aspx?valor="+Lib);
        }

        protected void GVBuscados_SelectedIndexChanged(object sender, EventArgs e)
        {
            //GridViewRow fila = GVBuscados.SelectedRow;

            //string Lib = fila.Cells[1].Text;
            //Response.Redirect("Libros.aspx?valor=" + Lib);

        }

        protected void ButtonEntrega_Click(object sender, EventArgs e)
        {
            var btn = (Button)sender;
            var item = (RepeaterItem)btn.NamingContainer;
            var ddl = (Button)item.FindControl("ButtonEntrega");
            var entregaId = ddl.Text.Split('-');
            var entregaDeVerdad = entregaId[0];
            Response.Redirect("MostrarEntrega2.aspx?valor=" + entregaDeVerdad);
        }

        protected void ButtonBuscarDrama_Click(object sender, EventArgs e)
        {
            Response.Redirect("BuscarEjemplares.aspx?valor=drama");
        }

        protected void ButtonBuscarAccion_Click(object sender, EventArgs e)
        {
            Response.Redirect("BuscarEjemplares.aspx?valor=accion");
        }

        protected void ButtonBuscarFiccion_Click(object sender, EventArgs e)
        {
            Response.Redirect("BuscarEjemplares.aspx?valor=ficcion");
        }

        protected void btnOpenModal_Click(object sender, EventArgs e)
        {
            divModalEntrega.Visible = true;
        }

        protected void abrirModalConfirmacion()
        {
            divModalEntrega.Visible = true;
        }
        protected void CloseModal(object sender, EventArgs e)
        {
            divModalEntrega.Visible = false;
        }

        protected void btnConfirmar_Click(object sender, EventArgs e)
        {
            NEntrega entregaManager = new NEntrega();
            entregaManager.cambiarEstadoEntrega(entregaParaConfirmar.Id);
            divModalEntrega.Visible = false;

        }

    }
}