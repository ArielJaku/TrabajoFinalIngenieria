using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Helpers;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.Net.Mail;


namespace TRABAJO1
{
    public class Utilidad : Page
    {
        public string UsuAct { get; set; }
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
        public void EnviarCorreo()
        {
            // Initialize WebMail helper
            WebMail.SmtpServer = "smtp.gmail.com";
            WebMail.SmtpPort = 587;
            WebMail.UserName = "";
            WebMail.Password = "";
            WebMail.From = "";
            WebMail.EnableSsl = true;

            // Send email
            WebMail.Send(to: "",
                subject: "Help request from - " + "Ariel Jakubowski",
                body: "Este es un cuadro de texto"
            );
        }
        public void EnviarCorreo2(string cuerpo)
        {
            var fromAddress = new MailAddress("Bibliotecatdd@gmail.com", "Biblioteca Digital");
            var toAddress = new MailAddress("ari_jaku@hotmail.com", "To Name");
            const string fromPassword = "ofedavjcfsgzqeko";
            const string subject = "Me interesa tu Ejemplar";
            string body = cuerpo;

            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential("Bibliotecatdd@gmail.com", fromPassword)
            };
            using (var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                Body = body
            })
            {
                smtp.Send(message);
            }
        }
    }
}