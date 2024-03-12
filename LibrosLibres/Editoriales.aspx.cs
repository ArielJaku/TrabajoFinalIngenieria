using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocios;
using Entidades;

namespace TRABAJO1
{
    public partial class Editoriales : Utilidad
    {   Neditorial oNeditorial = new Neditorial();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Usuario"] != null)
            {
                if (!Page.IsPostBack)
                {
                  
                    GVEditoriales.DataSource = oNeditorial.ConsultarEditorialesGV();
                    GVEditoriales.DataBind();

                }

            }
            else
            {
                MsgBox("Solo el rol de administrador puede modificar las editoriales", "Default.aspx");

            }
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            Editorial oEdit = new Editorial();
            oEdit.nombre = txtNombre.Text;
            oNeditorial.InsertarEditorial(oEdit);
            GVEditoriales.DataSource = oNeditorial.ConsultarEditorialesGV();
            GVEditoriales.DataBind();
          
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            Editorial oEdit = new Editorial();
            oEdit.id = int.Parse(lblID.Text);
            oEdit.nombre = txtNombre.Text;
            oNeditorial.ModificarEditorial(oEdit);
            GVEditoriales.DataSource = oNeditorial.ConsultarEditorialesGV();
            GVEditoriales.DataBind();

        }

        protected void btnBorrar_Click(object sender, EventArgs e)
        {
            Editorial oEdit = new Editorial();
            oEdit.id = int.Parse(lblID.Text);
            oNeditorial.BorrarEditorial(oEdit);
            GVEditoriales.DataSource = oNeditorial.ConsultarEditorialesGV();
            GVEditoriales.DataBind();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Editorial oEdit = new Editorial();
            oEdit.nombre = txtBuscarEjemplar.Text;
            GVEditoriales.DataSource = oNeditorial.ConsultarEditorialGV(oEdit);
            GVEditoriales.DataBind();
        }

        protected void GVEditoriales_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow filaL = GVEditoriales.SelectedRow;
            txtNombre.Text = filaL.Cells[2].Text;           
            lblID.Text = filaL.Cells[1].Text;
        }
    }
}