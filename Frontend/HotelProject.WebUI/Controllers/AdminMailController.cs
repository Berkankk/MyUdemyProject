using HotelProject.WebUI.Models.Mail;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using System.Net.Mail;

namespace HotelProject.WebUI.Controllers
{
    public class AdminMailController : Controller
    {

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]

        public IActionResult Index(AdminMailViewModel viewModel)
        {   //Kimden
            MimeMessage mimeMessage = new MimeMessage(); //Mimemessage sınıfından nesne ürettik , e postaları temsil eder
            MailboxAddress mailboxAddressFrom = new MailboxAddress("HotelierAdmin", "burası bizim mailimiz");
            mimeMessage.From.Add(mailboxAddressFrom); // oluşturulan maili gönderen listesine ekler
             
            //Kime
            MailboxAddress mailboxAddressTo = new MailboxAddress("User", viewModel.ReceiverMail);
            mimeMessage.To.Add(mailboxAddressTo); //oluşturulan maili alıcı listesine ekler to yardımı ile 

            //Mesajın içeriği
            var bodyBuilder = new BodyBuilder();
            bodyBuilder.TextBody = viewModel.Body;
            mimeMessage.Body = bodyBuilder.ToMessageBody();

            mimeMessage.Subject = viewModel.Subject;

            MailKit.Net.Smtp.SmtpClient client = new MailKit.Net.Smtp.SmtpClient();
            client.Connect("smtp.gmail.com", 587, false);
            client.Authenticate("mail", "password key");
            client.Send(mimeMessage);
            client.Disconnect(true);
            return View();
        }
    }
}
