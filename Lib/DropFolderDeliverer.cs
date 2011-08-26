using System;
using System.IO;
using System.Net.Mail;
using System.Text;
using System.Web;

namespace AnglicanGeek.MarkdownMailer
{
    public class DropFolderMailSenderService : IMailDeliverer
    {
        readonly MailSenderSettings settings;
        
        public DropFolderMailSenderService(MailSenderSettings settings)
        {
            this.settings = settings;
        }
        
        public void SendMail(
            MailAddress toAddress, 
            string subject, 
            string body)
        {
            
        }

        public void Deliver(MailMessage mailMessage)
        {
            mailMessage.

            var dropFolder = HttpContext.Current.Server.MapPath(configuration.MailSender.DropFolder);
            var filePath = Path.Combine(dropFolder, Guid.NewGuid() + ".txt");

            var contents = new StringBuilder();
            contents.AppendFormat("To: \"{0}\" <{1}>", toAddress.DisplayName, toAddress.Address);
            contents.AppendLine();
            contents.AppendFormat("Subject: {0}", subject);
            contents.AppendLine();
            contents.AppendLine();
            contents.Append(body);

            if (!Directory.Exists(dropFolder))
                Directory.CreateDirectory(dropFolder);

            File.WriteAllText(filePath, contents.ToString());
        }
    }
}