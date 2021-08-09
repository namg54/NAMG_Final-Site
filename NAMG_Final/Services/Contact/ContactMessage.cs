//using NAMG_Final.Services.Email;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using MailKit.Net.Smtp;
using MimeKit;
using MimeKit.Text;
using NAMG_Final.Services.Contact;
using Org.BouncyCastle.Crypto.Tls;

namespace NAMG_Final.Services.Contact
{
    public class ContactMessage : IContactMessage
    {
        public  string SendContactAsync(string name, string email, string subject, string htmlMessage)
        {
            using (var Client = new System.Net.Mail.SmtpClient())
            {
                var Credential = new NetworkCredential
                {

                    UserName = "contactus@namg.ir",
                    Password = "7heg73@$hT7"

                };
                Client.Credentials = Credential;
                Client.Host = "alvand.r1host.com";
                Client.Port = 25;
                Client.EnableSsl = true;
                using (var emailMessage = new MailMessage())
                {

                    emailMessage.To.Add(new MailAddress("contactus@namg.ir"));
                    emailMessage.From = new MailAddress("subscribe@namg.ir");
                    emailMessage.Subject =$"موضوع:{subject}";
                    emailMessage.IsBodyHtml = true; //contains html tag
                    emailMessage.Body = $" نام ارسال کننده:  {name}   <br/>ایمیل کاربر:   {email}   <br/>   متن پیام:   <br/>   {htmlMessage}";

                    Client.Send(emailMessage);
                };
                //await Task.CompletedTask;
                return null;
            }
        }
    }
}
//    public class ContactMessage : IContactMessage
//    {
//        public Task (string name, string email, string subject, string htmlMessage)
//        {
//            using (var Client = new System.Net.Mail.SmtpClient())
//            {
//                var Credential = new NetworkCredential
//                {

//                    UserName = "info@namg.ir",
//                    Password = "7heg73@$hT7"

//                };
//                Client.Credentials = Credential;
//                Client.Host = "alvand.r1host.com";
//                Client.Port = 25;
//                Client.EnableSsl = true;
//                using (var emailMessage = new MailMessage())
//                {

//                    emailMessage.To.Add(new MailAddress("info@namg.ir"));
//                    emailMessage.From = new MailAddress("subscribe@namg.ir");
//                    emailMessage.Subject = subject;
//                    emailMessage.IsBodyHtml = true; //contains html tag
//                    emailMessage.Body = htmlMessage;

//                    Client.Send(emailMessage);
//                };
//                await Task.CompletedTask;
//            }
//        }

//        //public async Task SendEmailAsync(string email, string subject, string message)
//        //{
//        //    using (var Client = new System.Net.Mail.SmtpClient())
//        //    {
//        //        var Credential = new NetworkCredential
//        //        {
                   
//        //            UserName = "info@namg.ir",
//        //            Password = "7heg73@$hT7"

//        //        };
//        //        Client.Credentials = Credential;
//        //        Client.Host = "alvand.r1host.com";
//        //        Client.Port = 25; 
//        //        Client.EnableSsl = true;
//        //        using (var emailMessage = new MailMessage())
//        //        {
                    
//        //            emailMessage.To.Add(new MailAddress("info@namg.ir"));
//        //            emailMessage.From = new MailAddress("subscribe@namg.ir");
//        //            emailMessage.Subject = subject;
//        //            emailMessage.IsBodyHtml = true; //contains html tag
//        //            emailMessage.Body = message;

//        //            Client.Send(emailMessage);
//        //        };
//        //        await Task.CompletedTask;
//        //    }
          
//        //}
//    //}
//}

