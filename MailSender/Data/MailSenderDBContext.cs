using MailSender.lib.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace MailSender.Data
{
    class MailSenderDBContext: DbContext
    {
        public DbSet<Recipient> Recipients { get; set; }
        public DbSet<Server> Servers { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Sender> Senders { get; set; }
        public DbSet<ShedulerTask> ShedulerTasks { get; set; }
        public DbSet<SentMessage> SentMessages { get; set; }
        public MailSenderDBContext(DbContextOptions<MailSenderDBContext> db) : base(db)
        {

        }
    }
}
