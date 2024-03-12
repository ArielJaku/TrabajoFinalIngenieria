using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocios;
using Entidades;
using System.Data;

namespace TRABAJO1
{
    public partial class Perfil : Utilidad
    {
        Nusuario VNU = new Nusuario();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Usuario"] != null)
            {
                if (!IsPostBack)
                {
                    DataTable Datos = VNU.TraerUsuario(Convert.ToInt32(Session["Usuario"]));
                    DDLciudades.DataSource = VNU.TraerLocalidades();
                    DDLciudades.DataTextField = "localidad";
                    DDLciudades.DataValueField = "cp";
                    DDLciudades.DataBind();
                    DDLprovincia.DataSource = VNU.TraerProvincias();
                    DDLprovincia.DataTextField = "provincia";
                    DDLprovincia.DataValueField = "id";
                    DDLprovincia.DataBind();
                    GVlibrosc.DataSource = VNU.TraerLibrosUsuario(Convert.ToInt32(Session["Usuario"]));
                    GVlibrosc.DataBind();
                    txtDNI.Text = Convert.ToString(Datos.Rows[0][0]);
                    txtUsuario.Text = Convert.ToString(Datos.Rows[0][1]);
                    txtApellido.Text = Convert.ToString(Datos.Rows[0][2]);
                    txtCalle.Text = Convert.ToString(Datos.Rows[0][3]);
                    txtNumCalle.Text = Convert.ToString(Datos.Rows[0][4]);
                    txtCorreo.Text = Convert.ToString(Datos.Rows[0][8]);
                    DDLciudades.SelectedIndex = Convert.ToInt32(Datos.Rows[0][5]);
                    DDLprovincia.SelectedIndex = Convert.ToInt32(Datos.Rows[0][6]);
                }

            }
            else
            {
                MsgBox("Inicie Sesion o Registrese para ver su Perfil", "Default.aspx");
            }
           

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            #region ProcesoViejo
            //int idlocalidad = Convert.ToInt32(DDLciudades.SelectedValue);
            //int idProvincia = Convert.ToInt32(DDLprovincia.SelectedValue);
            //int idRol = 2;
            //VNU.CargarUsuario(Convert.ToInt32(txtDNI.Text),txtUsuario.Text, txtApellido.Text, txtCalle.Text, Convert.ToInt32(txtNumCalle.Text), idlocalidad, idProvincia, idRol);
            #endregion
            int idlocalidad = Convert.ToInt32(DDLciudades.SelectedValue);
            int idProvincia = Convert.ToInt32(DDLprovincia.SelectedValue);
            Usuario usu = new Usuario();
            usu.DNI = Convert.ToInt32(txtDNI.Text);
            usu.Nombre = txtUsuario.Text;
            usu.apellido = txtApellido.Text;
            usu.direccion_calle = txtCalle.Text;
            usu.direccion_numero = Convert.ToInt32(txtNumCalle.Text);
            usu.Correo = txtCorreo.Text;
            usu.Idlocalidad = idlocalidad;
            usu.Idprovincia = idProvincia;            
            VNU.ModificarUsuario(usu);
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Response.Redirect("PerfilMostar.aspx");
        }
    }
}