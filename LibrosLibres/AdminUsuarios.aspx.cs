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
    public partial class AdminUsuarios : Utilidad
    {
        Nusuario VNU = new Nusuario();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) { 
            GridView1.DataSource = VNU.TraerUsuarios2();
            GridView1.DataBind();
            DDLprovincia.DataSource = VNU.TraerProvincias();
            DDLprovincia.DataTextField = "provincia";
            DDLprovincia.DataValueField = "id";
            DDLprovincia.DataBind();
            Provincia oProvincia = new Provincia();
            oProvincia.id = Convert.ToInt32(DDLprovincia.SelectedValue);
            DDLciudades.DataSource = VNU.TraerLocalidadesProvincia(oProvincia);
            DDLciudades.DataTextField = "localidad";
            DDLciudades.DataValueField = "cp";
            DDLciudades.DataBind();
            ddlRol.DataSource = VNU.TraerPermisos();
            ddlRol.DataTextField = "nombre";
            ddlRol.DataValueField = "id";
            ddlRol.DataBind();
            }
        }

        protected void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            
        }

        protected void Unnamed1_Click(object sender, EventArgs e)
        {
            Usuario oUsuario = new Usuario();
            oUsuario.Nombre = txtBuscar.Text;
            GridView1.DataSource = VNU.TraerUsuarios2(oUsuario);
            GridView1.DataBind();
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            Usuario oUsuario = new Usuario();
            oUsuario.DNI = Convert.ToInt32(txtDNI.Text);            
            oUsuario.Nombre = txtNombre.Text;
            oUsuario.apellido = txtApellido.Text;
            oUsuario.direccion_calle = txtCalle.Text;
            oUsuario.direccion_numero = Convert.ToInt32(txtNumCalle.Text);
            oUsuario.Correo = txtCorreo.Text;
            oUsuario.Idprovincia = Convert.ToInt32(DDLprovincia.SelectedValue);
            oUsuario.Idlocalidad = Convert.ToInt32(DDLciudades.SelectedValue);
            oUsuario.permisos = Convert.ToInt32(ddlRol.SelectedValue);

            Seguridad oSeguridad = new Seguridad();
            oSeguridad.DNIusuario= Convert.ToInt32(txtDNI.Text);
            string contraseña = txtContraseña.Text;
            contraseña=HashContraseña(contraseña);
            oSeguridad.contraseña = contraseña;
            oSeguridad.IDroles = Convert.ToInt32(ddlRol.SelectedValue);


            VNU.AgregarUsuario(oUsuario, oSeguridad);
            GridView1.DataSource = VNU.TraerUsuarios2();
            GridView1.DataBind();

        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            Usuario oUsuario = new Usuario();
            oUsuario.DNI = Convert.ToInt32(txtDNI.Text);
            oUsuario.Nombre = txtNombre.Text;
            oUsuario.apellido = txtApellido.Text;
            oUsuario.direccion_calle = txtCalle.Text;
            oUsuario.direccion_numero = Convert.ToInt32(txtNumCalle.Text);
            oUsuario.Correo = txtCorreo.Text;
            oUsuario.Idprovincia = Convert.ToInt32(DDLprovincia.SelectedValue);
            oUsuario.Idlocalidad = Convert.ToInt32(DDLciudades.SelectedValue);
            oUsuario.permisos = Convert.ToInt32(ddlRol.SelectedValue);

            Seguridad oSeguridad = new Seguridad();
            oSeguridad.DNIusuario = Convert.ToInt32(txtDNI.Text);
            string contraseña = txtContraseña.Text;
            contraseña = HashContraseña(contraseña);
            oSeguridad.contraseña = contraseña;
            oSeguridad.IDroles = Convert.ToInt32(ddlRol.SelectedValue);


            VNU.ModificarUsuario(oUsuario, oSeguridad);
            GridView1.DataSource = VNU.TraerUsuarios2();
            GridView1.DataBind();
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            Usuario oUsuario = new Usuario();
            oUsuario.DNI = Convert.ToInt32(txtDNI.Text);
            VNU.BorrarUsuario(oUsuario);
            GridView1.DataSource = VNU.TraerUsuarios2();
            GridView1.DataBind();

        }

        protected void DDLprovincia_SelectedIndexChanged(object sender, EventArgs e)
        {
            Provincia oProvincia = new Provincia();
            oProvincia.id = Convert.ToInt32(DDLprovincia.SelectedValue);           
            DDLciudades.DataSource = VNU.TraerLocalidadesProvincia(oProvincia);
            DDLciudades.DataTextField = "localidad";
            DDLciudades.DataValueField = "cp";
            DDLciudades.DataBind();
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow filaL = GridView1.SelectedRow;
            txtDNI.Enabled = false;
            txtDNI.Text = filaL.Cells[1].Text;
            txtNombre.Text = filaL.Cells[2].Text;
            txtApellido.Text = filaL.Cells[3].Text;
            txtCalle.Text = filaL.Cells[4].Text;
            txtNumCalle.Text = filaL.Cells[5].Text;
            DDLprovincia.SelectedValue = filaL.Cells[7].Text;
            DDLciudades.DataSource = VNU.TraerLocalidades();
            DDLciudades.DataTextField = "localidad";
            DDLciudades.DataValueField = "cp";
            DDLciudades.DataBind();
            DDLciudades.SelectedValue = filaL.Cells[6].Text;
            ddlRol.SelectedValue = filaL.Cells[8].Text;
            txtCorreo.Text = filaL.Cells[9].Text;

        }
    }
}