using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GmailTest.Business
{
    public class Mail
    {
        public string? Sender { get; set; }
        public string? Receiver { get; set; }
        public string? Subject { get; set; }
        public string? Body { get; set; }

        public Mail(string? sender = null, string? receiver = null, string? subject = null, string? body = null)
        {
            Sender = sender;
            Receiver = receiver;
            Subject = subject;
            Body = body;
        }

        public Mail() { }
    }
}
