using System.Threading.Tasks;

namespace Mailer.Sender.Interfaces
{
    public interface IEmailService
    {
        Task SendEmail(string email, string subject, string body);
    }
}
