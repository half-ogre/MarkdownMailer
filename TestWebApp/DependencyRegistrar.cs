using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AnglicanGeek.Mvc;
using AnglicanGeek.MarkdownMailer;
using System.Net.Mail;
using System.Net;

namespace TestWebApp {
    public class DependencyRegistrar : IDependencyRegistrar {
        Lazy<IMailSender> mailSenderThunk = new Lazy<IMailSender>(() => {
            var mailSenderConfiguration = new MailSenderConfiguration() {
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
        
        public void RegisterDependencies(IDependencyRegistry dependencyRegistry) {
            dependencyRegistry.RegisterCreator<IMailSender>(() => mailSenderThunk.Value);
        }
    }
}