using System.Threading.Tasks;

namespace Cinema.SL.Interfaces
{
    public interface IEmailService
    {
        Task SendEmailAsync(string email, string message);
    }
}
