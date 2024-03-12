using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Globalization;
using System.Web.Compilation;
using System.Web.Hosting;
using System.Web.Util;
using System.Security.Cryptography;
using System.Text;

namespace TRABAJO1
{
    public class Utilidad2 : MasterPage
    {
        public void MsgBox(string mensaje)
        {
            string msj = "<script language='javascript'> alert('" + mensaje + "');</script>";
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "mensaje", msj);
        }
        public void MsgBox(string mensaje, string pagina)
        {
            string script = @"alert('" + mensaje + "');window.location.href='" + pagina + "'";

            ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, true);
        }

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
        }
    }
}