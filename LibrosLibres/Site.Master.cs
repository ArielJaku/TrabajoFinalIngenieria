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
    public partial class SiteMaster : Utilidad2
    {
        ConexionSQLN cn = new ConexionSQLN();
        Nusuario VNU = new Nusuario();
        Auditoria oAuditoria = new Auditoria();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Id"] == null)
            {
                //lblU.Text = "";
                Cargar.Style["Visibility"] = "hidden";                
                Perfil.Style["Visibility"] = "hidden";
                Administracion.Style["Visibility"] = "hidden";
                cerrar.Style["Visibility"] = "hidden";
                reportes.Style["Visibility"] = "hidden";



            }
            else if (Session["Id"].ToString() == "2")
            {
                iniciar.Style["Visibility"] = "hidden";
                btnSesion.Style["Visibility"] = "hidden";
                registrar.Style["Visibility"] = "hidden";
                Administracion.Style["Visibility"] = "hidden";
                reportes.Style["Visibility"] = "hidden";
                cerrar.Style["Visibility"] = "visible";
                Cargar.Style["Visibility"] = "visible";
                Perfil.Style["Visibility"] = "visible";
                //lblU.Text = Session["Usuario"].ToString();
            }
            else if (Session["Id"].ToString() == "1")
            {
                iniciar.Style["Visibility"] = "hidden";
                btnSesion.Style["Visibility"] = "hidden";
                registrar.Style["Visibility"] = "hidden";
                Administracion.Style["Visibility"] = "visible";
                reportes.Style["Visibility"] = "visible";
                cerrar.Style["Visibility"] = "visible";
                Cargar.Style["Visibility"] = "visible";
                Perfil.Style["Visibility"] = "visible";
                //lblU.Text = Session["Usuario"].ToString();
            }
            else if (Session["Id"].ToString() == "3")
            {
                iniciar.Style["Visibility"] = "hidden";
                btnSesion.Style["Visibility"] = "hidden";
                registrar.Style["Visibility"] = "hidden";
                Administracion.Style["Visibility"] = "hidden";
                reportes.Style["Visibility"] = "hidden";
                cerrar.Style["Visibility"] = "visible";
                Cargar.Style["Visibility"] = "hidden";
                Perfil.Style["Visibility"] = "hidden";
                nosotros.Style["Visibility"] = "hidden";
                contacto.Style["Visibility"] = "hidden";
                ejemplares.Style["Visibility"] = "hidden";
                //lblU.Text = Session["Usuario"].ToString();
            }


        }

        protected void btnOpenModal_Click(object sender, EventArgs e)
        {
            divModal.Visible = true;
        }
        protected void CloseModal(object sender, EventArgs e)
        {
            divModal.Visible = false;
        }

        protected void btnIniciar_Click(object sender, EventArgs e)
        {
            int DNI = Convert.ToInt32(txtDni.Text);
            int ROL;
            var pass = HashContraseña(txtContraseña.Text);

            if (VNU.consultalogin(DNI, pass) == 1)
            {
                //MsgBox("El usuario existe");
                //UsuAct = Convert.ToString(DNI);
                //lblPru.Text = Convert.ToString(DNI);
                Session["Usuario"] = txtDni.Text;
                DNI = Convert.ToInt32(txtDni.Text);
                ROL = VNU.consultaRol(DNI);
                Session["Id"] = ROL.ToString();
                oAuditoria.LogSession(DNI, "El usuario pudo ingresar al sistema");
                Response.Redirect("Default.aspx");
               
            }
            else
            {
                oAuditoria.LogSession(0, "fallo ingreso al sistema");
                MsgBox("El usuario o la contraseña no son correctos");
            }
        }



    }
}