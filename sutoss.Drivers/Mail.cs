using FluentEmail.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mail
{
    public class Mail
    {
        public List<Address> SendTo { get; set; }
        public string EmailAddress { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public Mail(List<string> to, string from, string subject, string body)
        {
            SendTo = new();
            foreach(var email in to)
            {
                SendTo.Add(new Address { Name = "",EmailAddress= email }) ;
            }
            EmailAddress = from;
            Subject = subject;
            Body = body;
        }
    }
}
