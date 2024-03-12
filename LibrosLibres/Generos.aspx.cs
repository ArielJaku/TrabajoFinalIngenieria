using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades;
using Negocios;

namespace TRABAJO1
{
    public partial class Generos : Utilidad
    {
        NGenero oNG = new NGenero();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Usuario"] != null)
            {
                if (!Page.IsPostBack)
                {

                    GVGeneros.DataSource = oNG.ConsultarGenerosGV();
                    GVGeneros.DataBind();

                }

            }
            else
            {
                MsgBox("Solo el rol de administrador puede modificar las editoriales", "Default.aspx");

            }

        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            Genero oGen = new Genero();
            oGen.Nombre = txtNombre.Text;
            oNG.InsertarGenero(oGen);
            GVGeneros.DataSource = oNG.ConsultarGenerosGV();
            GVGeneros.DataBind();

        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            Genero oGen = new Genero();
            oGen.Id = int.Parse(lblID.Text);
            oGen.Nombre = txtNombre.Text;
            oNG.ModificarGenero(oGen);
            GVGeneros.DataSource = oNG.ConsultarGenerosGV();
            GVGeneros.DataBind();

        }

        protected void btnBorrar_Click(object sender, EventArgs e)
        {
            Genero oGen = new Genero();
            oGen.Id = int.Parse(lblID.Text);
            oNG.BorrarGenero(oGen);
            GVGeneros.DataSource = oNG.ConsultarGenerosGV();
            GVGeneros.DataBind();

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Genero oGen = new Genero();
            oGen.Nombre = txtBuscarEjemplar.Text;
            GVGeneros.DataSource = oNG.ConsultarGenerosGV(oGen);
            GVGeneros.DataBind();
        }

        protected void GVEditoriales_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow filaL = GVGeneros.SelectedRow;
            txtNombre.Text = filaL.Cells[2].Text;
            lblID.Text = filaL.Cells[1].Text;
        }
    }
}