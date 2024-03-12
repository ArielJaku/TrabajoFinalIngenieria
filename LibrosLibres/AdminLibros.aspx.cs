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
    public partial class AdminLibros : System.Web.UI.Page
    {
        Nlibro oNLibro = new Nlibro();
        Nautor oNAutor = new Nautor();
        NGenero oNGenero = new NGenero();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack) { 
            GVLibros.DataSource = oNLibro.ConsultarLibrosGV1();
            GVLibros.DataBind();
            ddlAutor.DataSource = oNAutor.ConsultarAutoresGV();
            ddlAutor.DataTextField = "apellido";
            ddlAutor.DataValueField = "id";
            ddlAutor.DataBind();
            ddlGenero.DataSource = oNGenero.ConsultarGenerosGV();
            ddlGenero.DataTextField = "genero";
            ddlGenero.DataValueField = "id";
            ddlGenero.DataBind();
            }
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            Libro oLibro = new Libro();            
            oLibro.isbn = int.Parse(txtIsbn.Text);
            oLibro.nombre = txtNombre.Text;
            oLibro.stock = int.Parse(txtStock.Text);
            var idA = Convert.ToInt32(ddlAutor.SelectedValue);
            oLibro.idAutor = idA;
            var idG = Convert.ToInt32(ddlGenero.SelectedValue);
            oLibro.idGenero = idG;
            oNLibro.CargarLibro(oLibro);
            GVLibros.DataSource = oNLibro.ConsultarLibrosGV1();
            GVLibros.DataBind();
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            Libro oLibro = new Libro();
            oLibro.id = int.Parse(lblID.Text);
            oLibro.isbn = int.Parse(txtIsbn.Text);
            oLibro.nombre = txtNombre.Text;
            oLibro.stock = int.Parse(txtStock.Text);
            var idA = Convert.ToInt32(ddlAutor.SelectedValue);
            oLibro.idAutor = idA;
            var idG = Convert.ToInt32(ddlGenero.SelectedValue);
            oLibro.idGenero = idG;
            oNLibro.ModificarLibro(oLibro);
            GVLibros.DataSource = oNLibro.ConsultarLibrosGV1();
            GVLibros.DataBind();


        }

        protected void btnBorrar_Click(object sender, EventArgs e)
        {
            Libro oLibro = new Libro();
            oLibro.id = int.Parse(lblID.Text);
            oNLibro.BorrarLibro(oLibro);
            GVLibros.DataSource = oNLibro.ConsultarLibrosGV1();
            GVLibros.DataBind();
          
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Libro oLibro = new Libro();
            oLibro.nombre = txtBuscarLibro.Text;
            GVLibros.DataSource = oNLibro.ConsultarLibrosGV1(oLibro);
            GVLibros.DataBind();

        }

        protected void GVLibros_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow filaL = GVLibros.SelectedRow;
            txtNombre.Text = filaL.Cells[3].Text;
            lblID.Text = filaL.Cells[1].Text;
            txtIsbn.Text = filaL.Cells[2].Text;
            txtStock.Text = filaL.Cells[5].Text;
            ddlAutor.SelectedValue= filaL.Cells[4].Text;
            ddlGenero.SelectedValue = filaL.Cells[6].Text;                      

        }
    }
}