using System.Net.Mail;

namespace AnglicanGeek.MarkdownMailer
{
    public interface IMailDeliverer
    {
        public void Deliver(MailMessage mailMessage);
    }
}
