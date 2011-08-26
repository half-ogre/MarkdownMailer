using System.Net.Mail;

namespace AnglicanGeek.MarkdownMailer
{
    public interface IMailSender
    {
        void Send(
            string fromAddress,
            string toAddress,
            string subject,
            string markdownBody);

        void Send(
            MailAddress fromAddress,
            MailAddress toAddress,
            string subject,
            string markdownBody);

        void Send(MailMessage mailMessage);
    }
}