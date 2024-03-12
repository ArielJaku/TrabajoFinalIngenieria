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
    public partial class autores : Utilidad
    {
        Nautor VNA = new Nautor();
        int idpais;
        int idautor;
    
     
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Usuario"]!=null)
            {
                if (!Page.IsPostBack)
                {
                    idpais = 1;
                    DDLpaises.DataSource = VNA.PaisesCB();
                    DDLpaises.DataTextField = "pais";
                    DDLpaises.DataValueField = "id";
                    DDLpaises.DataBind();
                    GVautores.DataSource = VNA.ConsultarAutoresGV();                    
                    GVautores.DataBind();
                    
                }

            }
            else
            {
                MsgBox("Solo el rol de administrador puede modificar los autores", "Default.aspx");                
                
            }
            
        }

        protected void btnCargar_Click(object sender, EventArgs e)
        {
            var idp = Convert.ToInt32(DDLpaises.SelectedValue);
            DDLpaises.DataBind();
            VNA.NInsertarAutor(txtNombre.Text, txtApe.Text, idp);
            GVautores.DataSource = VNA.ConsultarAutoresGV();
            GVautores.DataBind();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            GVautores.DataSource = VNA.ConsultarAutoresGV(txtBuscarAutor.Text);
            GVautores.DataBind();

        }

        protected void DDLpaises_SelectedIndexChanged(object sender, EventArgs e)
        {
            idpais = int.Parse(DDLpaises.SelectedValue);
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            idautor = int.Parse(lblID.Text);
            var idp = Convert.ToInt32(DDLpaises.SelectedValue);
            DDLpaises.DataBind();
            Autor oAutor = new Autor();
            oAutor.Id = idautor;
            oAutor.Nombre = txtNombre.Text;
            oAutor.Apellido = txtApe.Text;
            oAutor.idpais = idp;
            VNA.ModificarAutor(oAutor);
            GVautores.DataSource = VNA.ConsultarAutoresGV();
            GVautores.DataBind();

        }

        protected void btnBorrar_Click(object sender, EventArgs e)
        {
            Autor oAutor = new Autor();
            idautor = int.Parse(lblID.Text);
            oAutor.Id = idautor;
            VNA.BorrarAutor(oAutor);
            GVautores.DataSource = VNA.ConsultarAutoresGV();
            GVautores.DataBind();
        }

        protected void GVautores_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {

        }

        protected void GVautores_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow filaL = GVautores.SelectedRow;            
            txtNombre.Text = filaL.Cells[2].Text;
            txtApe.Text = filaL.Cells[3].Text;
            DDLpaises.SelectedValue= filaL.Cells[4].Text;
            idpais = Convert.ToInt32(DDLpaises.SelectedValue);            
            lblID.Text = filaL.Cells[1].Text;
            
        }
    }
}