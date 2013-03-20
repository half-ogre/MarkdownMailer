using System.Web;
using AnglicanGeek.Mvc;
using System.Net.Mail;
using MarkdownMailer;

namespace TestWebApp {
    public class DependencyRegistrar : IDependencyRegistrar {
        public void RegisterDependencies(IDependencyRegistry dependencyRegistry)
        {
            dependencyRegistry.RegisterCreator<IMailSender>(() =>
            {
                var mailSenderConfiguration = new MailSenderConfiguration
                {
                    DeliveryMethod = SmtpDeliveryMethod.SpecifiedPickupDirectory,
                    PickupDirectoryLocation = HttpContext.Current.Server.MapPath("~/App_Data/Mail")
                };

                //var mailSenderConfiguration = new MailSenderConfiguration() {
                //    DeliveryMethod = SmtpDeliveryMethod.Network,
                //    EnableSsl = true,
                //    Host = "smtp.gmail.com",
                //    Port = 587,
                //    UseDefaultCredentials = false,
                //    Credentials = new NetworkCredential("<your-gmail-address>", "<your-gmail-password>") 
                //};

                return new MailSender(mailSenderConfiguration);
            });
        }
    }
}