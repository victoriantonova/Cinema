using System.Threading.Tasks;

namespace Cinema.SL.Interfaces
{
    public interface IEmailService
    {
        void SendEmailAsync(string email, string message);
    }
}
