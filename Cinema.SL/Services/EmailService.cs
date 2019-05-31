using Cinema.SL.Interfaces;
using MailKit.Net.Smtp;
using MimeKit;
using System.Threading.Tasks;

namespace Cinema.SL.Services
{
    public class EmailService : IEmailService
    {
        public async Task SendEmailAsync(string email, string message)
        {
            MimeMessage emailMessage = new MimeMessage();

            emailMessage.From.Add(new MailboxAddress("Администрация сайта", "victori.antonovav@gmail.com"));
            emailMessage.To.Add(new MailboxAddress("", email));
            emailMessage.Subject = "Регистрация";
            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = message
            };

            using (SmtpClient client = new SmtpClient())
            {
                await client.ConnectAsync("smtp.gmail.com", 587, false);
                await client.AuthenticateAsync("victori.antonovav@gmail.com", "pil445439200");
                await client.SendAsync(emailMessage);

                await client.DisconnectAsync(true);
            }
        }
    }
}
