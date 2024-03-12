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
    public partial class IniciarSesion : Utilidad
    {
        //ConexionSQLN cn = new ConexionSQLN();
        Nusuario VNU = new Nusuario();
        Auditoria oAuditoria = new Auditoria();  
        
        
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnIniciar_Click(object sender, EventArgs e)
        {
            int DNI = Convert.ToInt32(txtDni.Text);
            int ROL = 2;
            var pass = HashContraseña(txtContraseña.Text);
            Seguridad seg = new Seguridad();
            seg.DNIusuario = DNI;
            seg.contraseña = pass;
            seg.IDroles = ROL;
            try
            {
                VNU.ModificarSeguridad(seg);
                MsgBox("Su contraseña ah sido modificada con exito");
                //Response.Redirect("Default.aspx");
            }
            catch (Exception)
            {
                MsgBox("No existe ese dni en la base de datos");
                
            }
            
           
        }
        //protected void btnGuardar_Click(object sender, EventArgs e)
        //{
            
        //    //MsgBox("Session de usuario guardada");
        //    Response.Redirect("Default.aspx");
        //}
        protected void btnSalir_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }
    }
}