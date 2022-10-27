using FluentEmail.Core;
using FluentEmail.Smtp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Mail
{
    public class MailService
    {
        private string Host { get; set; } 
        private int Port { get; set; } 
        private bool Ssl { get; set; }
        private string UserName { get; set; } 
        private string Pass { get; set; }

        public MailService(string host, int port, bool ssl, string userName, string pass)
        {
            Host = host;
            Port = port;
            Ssl = ssl;
            UserName = userName;
            Pass = pass;
        }

        public async Task SendEmail(Mail maildata)
        {
            //Create sender
            var sender = new SmtpSender(() => new SmtpClient(this.Host)
            {
                DeliveryMethod = SmtpDeliveryMethod.Network,
                Port = this.Port,
                UseDefaultCredentials = false,
                EnableSsl = this.Ssl,
                Credentials = new System.Net.NetworkCredential(UserName, Pass)
            });

            //Set Sender
            Email.DefaultSender = sender;

            //Send Email
            var email = await Email
                .From(maildata.EmailAddress)
                .BCC(maildata.SendTo)
                .Subject(maildata.Subject)
                .Body(maildata.Body)
                .SendAsync();
        }
    }
}
