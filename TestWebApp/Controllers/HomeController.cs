using System.Web.Mvc;
using System.Net.Mail;
using System;
using MarkdownMailer;

namespace TestWebApp.Controllers
{
    public class HomeController : Controller
    {
        readonly IMailSender mailSender;
        
        public HomeController(IMailSender mailSender) {
            this.mailSender = mailSender;
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(SendMailRequest request) {
            if (!ModelState.IsValid)
                return View();

            try {
                mailSender.Send(
                    new MailAddress(request.From),
                    new MailAddress(request.To),
                    request.Subject,
                    request.Body);
            }
            catch (Exception ex) {
                ModelState.AddModelError(string.Empty, ex.Message);
                return View();
            }

            return RedirectToRoute("Default");
        }
    }
}
