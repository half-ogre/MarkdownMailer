using System.Net;
using System.Net.Mail;

namespace CampaignNarrative
{
    public class SmtpMailSenderService : IMailSenderService
    {
        readonly Configuration configuration;
        
        public SmtpMailSenderService(Configuration configuration)
        {
            this.configuration = configuration;
        }
        
        public void SendMail(
            MailAddress toAddress,
            string subject,
            string markdownBody)
        {
            var smtp = new SmtpClient
            {
                Host = configuration.MailSender.SmtpHost,
                Port = configuration.MailSender.SmtpPort,
                EnableSsl = configuration.MailSender.SmtpUseSsl,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(
                    configuration.MailSender.FromAddress,
                    configuration.MailSender.FromPassword)
            };

            var fromAddress = new MailAddress(
                configuration.MailSender.FromAddress,
                configuration.MailSender.FromName);
            
            var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                Body = markdownBody,
                
            };
            
            using (message)
            {
                smtp.Send(message);
            }
        }
    }
}