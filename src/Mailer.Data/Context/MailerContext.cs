using Mailer.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Mailer.Data.Context
{
    public class MailerContext : DbContext
    {
        public MailerContext(DbContextOptions<MailerContext> options) : base(options)
        { }

        public DbSet<Mail> Mails { get; set; }
    }
}
