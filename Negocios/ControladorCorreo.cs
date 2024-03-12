using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Negocios
{
    public class ControladorCorreo
    {
        public string EnviarCorreo2(string cuerpo)
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

            return "ok";
        }
    }
}
