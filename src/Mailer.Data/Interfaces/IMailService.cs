using Mailer.Data.Entities;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Mailer.Data.Interfaces
{
    public interface IMailService
    {
        Task<Mail> Sent(Mail mail);
        Task<List<Mail>> Get();
        Task<List<Mail>> GetSents();
        Task<List<Mail>> Get(string id);
    }
}
