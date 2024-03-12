using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocios;
using Entidades;

namespace TRABAJO1
{
    public partial class Registrarse : Utilidad
    {
        Nusuario VNU = new Nusuario();
        Auditoria oAuditoria = new Auditoria();
        protected void Page_Load(object sender, EventArgs e)
        {
            {
                if (!IsPostBack)
                {
                    DDLciudades.DataSource = VNU.TraerLocalidades();
                    DDLciudades.DataTextField = "localidad";
                    DDLciudades.DataValueField = "cp";
                    DDLciudades.DataBind();
                    DDLprovincia.DataSource = VNU.TraerProvincias();
                    DDLprovincia.DataTextField = "provincia";
                    DDLprovincia.DataValueField = "id";
                    DDLprovincia.DataBind();
                }

            }

        }

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {

            //VALIDACION SI EL DNI EXISTE
            if (VNU.consultaExistencia(Convert.ToInt32(txtDNI.Text)) == 0)
            {
                string pass = txtCont.Text;
                var pas = HashContraseña(pass);
                int idlocalidad = Convert.ToInt32(DDLciudades.SelectedValue);
                int idProvincia = Convert.ToInt32(DDLprovincia.SelectedValue);
                int idRol = 2;
                VNU.RegistrarUsuario(Convert.ToInt32(txtDNI.Text), txtUsuario.Text, txtApellido.Text, txtCalle.Text, Convert.ToInt32(TextBox1.Text), idlocalidad, idProvincia, idRol, txtCorreo.Text, pas);
                oAuditoria.LogAccion(Convert.ToInt32(txtDNI.Text), "Se Registro con exito el usuario");
            }
            else
            {
                MsgBox("Ese DNI ya esta registrado en nuestra Base de Datos");
            }
        }
        /*
        public string HashContraseña(string con) 
        {
            using (var sha256 = SHA256.Create())
            {
                // Send a sample text to hash.  
                var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(con));
                // Get the hashed string.  
                var co = BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
                // Print the string.   
                //Console.WriteLine(co);

                return co;
            }

        }*/

    }
}