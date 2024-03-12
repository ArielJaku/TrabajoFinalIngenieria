using Entidades;
using Microsoft.SqlServer.Server;
using Negocios;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TRABAJO1
{
    public partial class MostrarEntrega2 : Utilidad
    {
        NEntrega ControladorEntrega = new NEntrega();
        public Entrega EntregaID;
        protected void Page_Load(object sender, EventArgs e)
        {
            var idEntrega = Request.QueryString["valor"].ToString();            
            var Entrega = ControladorEntrega.traerEntrega(Convert.ToInt32(idEntrega));
            EntregaID = Entrega;
            lblBusqueda.Text = Entrega.DireccionEntregaInicio;
            lblEntrega.Text = Entrega.DireccionEntregaFin;
            if(Entrega.EstadoEntrega == 1)
            {
                btnEstadoEntrega.Text = "INICIAR ENTREGA";
                btnEstadoEntrega.BackColor = Color.Green;
                btnEstadoEntrega.Style["color"] = "white";
            }else if (Entrega.EstadoEntrega == 2)
            {
                btnEstadoEntrega.Text = "FINALIZAR ENTREGA";
                btnEstadoEntrega.BackColor = Color.Yellow;
                btnEstadoEntrega.Style["color"] = "blue";
            }else if (Entrega.EstadoEntrega == 3)
            {
                btnEstadoEntrega.Text = "ESPERANDO CONFIRMACION";
                btnEstadoEntrega.BackColor = Color.Red;
                btnEstadoEntrega.Style["color"] = "white";
            }else if (Entrega.EstadoEntrega == 4)
            {
                btnEstadoEntrega.Text = "ENTREGA FINALIZADA";
                btnEstadoEntrega.BackColor = Color.Black;
                btnEstadoEntrega.Style["color"] = "white";
                btnEstadoEntrega.Enabled = false;
            }

        }
        protected void ButtonEntrega_Click(object sender, EventArgs e)
        {
            if(EntregaID.EstadoEntrega != 3) 
            {
                ControladorEntrega.cambiarEstadoEntrega(EntregaID.Id);
            }
            else
            {
                MsgBox("El cliente debe confirmar la entrega");
            }
            
        }
    }
}