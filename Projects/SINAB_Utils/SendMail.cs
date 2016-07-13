using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.Mail;
using MailMessage = System.Net.Mail.MailMessage;
using MailPriority = System.Net.Mail.MailPriority;

namespace SINAB_Utils
{
    public static class SendMail
    {
        /// <summary>
        /// Envía correo de Convocatoria de Bases de Licitación a proveedor
        /// </summary>
        /// <param name="to">Destinatario</param>
        /// <param name="subject">Título del correo</param>
        /// <param name="body">Cuerpo del Correo</param>
        /// <param name="cc">(Opcional) Copia al Carbón</param>
        /// <param name="bcc">(Opcional) Copia al Carbón oculta</param>
        public static void SendToProvider(string to, string subject,  string body,  string cc = "", string bcc = "")
        {
            var mail = new MailMessage("sinab@salud.gob.sv", to, subject, body)
                       {
                           IsBodyHtml = true,
                           Priority = MailPriority.High
                       };
            if(!string.IsNullOrEmpty(cc)) mail.CC.Add(cc);       
            if(!string.IsNullOrEmpty(bcc)) mail.Bcc.Add(bcc);
            
            var client = new SmtpClient("mail.salud.gob.sv")
                         {
                             EnableSsl = true,
                             DeliveryMethod = SmtpDeliveryMethod.Network,
                             UseDefaultCredentials =  false,
                             Credentials = new NetworkCredential("sinab","Sin_1982")
                         };
            try
            {
                client.Send(mail);
            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            }

        }

        public static void Send(string to, string subject,  string body)
        {
            var mail = new MailMessage("sinab@salud.gob.sv", to, subject , body)
            {
                IsBodyHtml = true,
                Priority = MailPriority.High
            };
          
            var client = new SmtpClient("mail.salud.gob.sv")
            {
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential("sinab", "Sin_1982")
            };
            try
            {
                client.Send(mail);
            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            }

        }

        public static string ReadRegisterProviderTemplate()
        {
            var html = File.ReadAllText(HttpContext.Current.Server.MapPath("~/PlantillasCorreo/TplProvRegSol.html"));
            if (string.IsNullOrEmpty(html)) throw new Exception("No se encontró la plantilla");
            return html;
        }

        public static string ReadLoginProviderTemplate()
        {
            var html = File.ReadAllText(HttpContext.Current.Server.MapPath("~/PlantillasCorreo/TplProvLoginSol.html"));
            if (string.IsNullOrEmpty(html)) throw new Exception("No se encontró la plantilla");
            return html;
        }

        public static string ReadActivateProviderTemplate()
        {
            var html = File.ReadAllText(HttpContext.Current.Server.MapPath("~/PlantillasCorreo/TplProvActivateSol.html"));
            if (string.IsNullOrEmpty(html)) throw new Exception("No se encontró la plantilla");
            return html;
        }

        public static string ReadDateTimeAdviseTemplate()
        {
            var html = File.ReadAllText(HttpContext.Current.Server.MapPath("~/PlantillasCorreo/TplAdminDateTimeAdvise.html"));
            if (string.IsNullOrEmpty(html)) throw new Exception("No se encontró la plantilla");
            return html; 
        }
    }
}