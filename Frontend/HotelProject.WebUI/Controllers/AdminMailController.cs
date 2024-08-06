using HotelProject.WebUI.Models.Mail;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
        public IActionResult Index(AdminMailViewModel model) //sendmessage tablosunun veri gonderme islerinin yapildigi controller a bu mesajlari ekle . . .
        {
            MimeMessage mimeMessage = new MimeMessage();

            MailboxAddress mailboxAddressFrom = new MailboxAddress("HotelierAdmin", "orctrn194@gmail.com"); //kimden
            mimeMessage.From.Add(mailboxAddressFrom);                                                  //kimden

            MailboxAddress mailboxAddressTo = new MailboxAddress("User", model.ReceiverMail);//kime
            mimeMessage.To.Add(mailboxAddressTo);                                            //kime

            var bodyBuilder = new BodyBuilder();             //mesajin icerigi
            bodyBuilder.TextBody = model.Body;               //mesajin icerigi
            mimeMessage.Body = bodyBuilder.ToMessageBody();  //mesajin icerigi

            mimeMessage.Subject = model.Subject;

            SmtpClient smtpClient = new SmtpClient();
            smtpClient.Connect("smtp.gmail.com", 587, false);
            smtpClient.Authenticate("orctrn194@gmail.com", "uxyx bdcj rnqr nljr");
            smtpClient.Send(mimeMessage);
            smtpClient.Disconnect(true);

            //Gonderilen mailin veri tabanina kayit edilmesi . . . 

            return View();
        }
    }
}
