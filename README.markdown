_**NOTICE! This repo is very outdated and is no longer maintained.**_

MarkdownMailer is a simple library for sending email message with Markdown bodies, that creates the text and HTML views from the Markdown.

# How to Use

## Install

    Install-Package MarkdownMailer

## Configure

You can either pass a MailSenderConfiguration instance to the MailSender ctor, e.g.:

```
var mailSenderConfiguration = new MailSenderConfiguration() {
    DeliveryMethod = SmtpDeliveryMethod.Network,
    EnableSsl = true,
    Host = "smtp.gmail.com",
    Port = 587,
    UseDefaultCredentials = false,
    Credentials = new NetworkCredential("fnord@gmail,com", "password")
};

var mailSender = new MailSender(mailSenderConfiguration);
```
Or, you can use the default <system.net> applicaton (or web) configuration, e.g.:

```
<system.net>
    <mailSettings>
    <smtp deliveryMethod="Network">
        <network 
		host="smtp.gmail.com" 
		enableSsl = "true" 
        userName="fnord@gmail.com" 
        password="password" 
		port="587"/>
    </smtp>
    </mailSettings>
</system.net>
```
## Use

```
var mailSender = new MailSender();
mailSender.Send("from@address.com", "to@address.com", "Test", "This is a **test**");
```
