using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;

namespace LocationApp.Core.Helper
{
    public class Postman
    {
        public static string Username { get; set; }
        public static string Password { get; set; }
        public static string Host { get; set; }
        public static int Port { get; set; }
        public static bool SSL { get; set; }

        public string ToEmail { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public bool IsHtml { get; set; }

        static Postman()
        {
            Username = "culocationapp@gmail.com";
            Password = "LocationApp1234";
            Host = "smtp.gmail.com";
            Port = 587; // Gmail SSL sertifikası olan sunucularla 25 portu üzerinden konuşuyor. Güvenliksiz port no: 587.
            SSL = true;
        }

        public void Send()
        {
            SmtpClient smtp = new SmtpClient();
            smtp.Host = Host;
            smtp.Port = Port;
            smtp.EnableSsl = SSL;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential(Username, Password);


            using (var message = new MailMessage(Username, ToEmail))
            {
                message.Subject = Subject;
                message.Body = Body;
                message.IsBodyHtml = IsHtml;
                smtp.Send(message);
            }
        }
    }
}