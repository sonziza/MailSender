using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Text;

namespace MailSender.Data
{
    class MailSenderDBContextInitializer : IDesignTimeDbContextFactory<MailSenderDBContext>
    {
        public MailSenderDBContext CreateDbContext(string[] args)
        {
            const string connection_string = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=MailSender.DB;Integrated Security=True";

            var optionsBuilder = new DbContextOptionsBuilder<MailSenderDBContext>();
            optionsBuilder.UseSqlServer(connection_string);

            return new MailSenderDBContext(optionsBuilder.Options);
        }
    }
}
