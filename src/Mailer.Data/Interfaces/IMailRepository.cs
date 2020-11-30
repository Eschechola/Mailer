using Mailer.Data.Entities;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Mailer.Data.Interfaces
{
    public interface IMailRepository
    {
        Task<Mail> Add(Mail mail);
        Task<Mail> Update(Mail mail);
        Task<List<Mail>> Get();
        Task<List<Mail>> GetSents();
        Task<List<Mail>> Get(string id);
    }
}
