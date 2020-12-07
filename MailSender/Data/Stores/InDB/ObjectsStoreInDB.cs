using MailSender.lib.Interfaces;
using MailSender.lib.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MailSender.Data.Stores.InDB
{
    class RecipientsStoreInDB : StoreInDB<Recipient>
    {
        public RecipientsStoreInDB(MailSenderDBContext db) : base(db) { }
    }

    class SendersStoreInDB : StoreInDB<Sender>
    {
        public SendersStoreInDB(MailSenderDBContext db) : base(db) { }
    }

    class ServersStoreInDB : StoreInDB<Server>
    {
        public ServersStoreInDB(MailSenderDBContext db) : base(db) { }
    }

    class MessagesStoreInDB : StoreInDB<Message>
    {
        public MessagesStoreInDB(MailSenderDBContext db) : base(db) { }
    }

    class SentMessagesStoreInDB : StoreInDB<SentMessage>
    {
        public SentMessagesStoreInDB(MailSenderDBContext db): base(db) { }
    }
}
