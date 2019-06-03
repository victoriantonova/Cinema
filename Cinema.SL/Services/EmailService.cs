using Cinema.SL.Interfaces;
using MailKit.Net.Smtp;
using MimeKit;
using System.Threading.Tasks;

namespace Cinema.SL.Services
{
    public class EmailService : IEmailService
    {
        public void SendEmailAsync(string email, string message)
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
                client.Connect("smtp.gmail.com", 587, false);
                client.Authenticate("victori.antonovav@gmail.com", "pil445439200");
                //client.Connect("smtp.yandex.ru", 25, false);
                //client.Authenticate("aliona.sauchuk@yandex.by", "qwe123.");
                client.Send(emailMessage);

                client.Disconnect(true);
            }
        }
    }
}
