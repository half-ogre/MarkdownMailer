using System;
using System.Net.Mail;
using System.Net;

namespace MarkdownMailer
{
    internal interface ISmtpClient : IDisposable
    {
        ICredentialsByHost Credentials { get; set; }
        SmtpDeliveryMethod DeliveryMethod { get; set; }
        bool EnableSsl { get; set; }
        string Host { get; set; }
        string PickupDirectoryLocation { get; set; }
        int Port { get; set; }
        void Send(MailMessage message);
        bool UseDefaultCredentials { get; set; }
    }
}
