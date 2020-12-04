using MailSender.lib.Models.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace MailSender.lib.Models
{
    public class MessageSent: Entity
    {
        public string AddresFrom { get; set; }
        public string AssressTo { get; set; }
        public DateTime DateTimeSent { get; set; }
        public string MessageSubject { get; set; }
        public string MessageBody { get; set; }
    }
}
