using System.Linq;
using System.Threading.Tasks;
using Mailer.Data.Context;
using Mailer.Data.Entities;
using Mailer.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Mailer.Data.Repository
{
    public class MailRepository : IMailRepository
    {
        private readonly MailerContext _context;

        public MailRepository(MailerContext context)
        {
            _context = context;
        }

        public async Task<Mail> Add(Mail mail)
        {
            _context.Add(mail);
            await _context.SaveChangesAsync();

            return mail;
        }

        public async Task<Mail> Update(Mail mail)
        {
            _context.Entry(mail).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return mail;
        }

        public async Task<List<Mail>> Get()
        {
            return await _context.Mails.ToListAsync();
        }

        public async Task<List<Mail>> Get(string id)
        {
            return await _context.Mails.Where(x => x.Id == id).ToListAsync();
        }

        public async Task<List<Mail>> GetSents()
        {
            return await _context.Mails.Where(x => x.IsSent == true).ToListAsync();
        }
    }
}
