using MailSender.lib.Interfaces;
using MailSender.lib.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MailSender.lib.Service
{
    class SentMessageService : IMailSender
    {
        public void Send(string SenderAddress, string RecipientAddress, string Subject, string Body)
        {
            SentMessage sentMessage = new SentMessage()
            {
                AddresFrom = SenderAddress,
                AssressTo = RecipientAddress,
                DateTimeSent = DateTime.Now,
                MessageSubject = Subject,
                MessageBody = Body,
            };
            //SentMessages.Add(sentMessage);
        }
    }
}
