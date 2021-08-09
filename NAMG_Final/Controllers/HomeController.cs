using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NAMG_Final.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using NAMG_Final.Data;
using NAMG_Final.Services;
using NAMG_Final.Services.Contact;
using NAMG_Final.Services.Email;
using ZarinpalSandbox;

namespace NAMG_Final.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IMessageService _messageService;
        private IContactMessage _contactMessage;
        private MySiteContext _context;
        public HomeController(ILogger<HomeController> logger, MySiteContext context,IMessageService messageService, IContactMessage contactMessage)
        {
            _logger = logger;
            _context = context;
            _messageService = messageService;
            _contactMessage = contactMessage;
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Contact(ContactViewModel cvm)
        {
            return View();
        }
        [HttpPost]
        public IActionResult ContactUs(ContactViewModel cvm)
        {
            //await _messageService.SendEmailAsync("info@namg.ir", "میخواهد سایت ما را دنبال کند", email.body);
             _contactMessage.SendContactAsync(cvm.name,cvm.email,cvm.subject,cvm.message);
             return Redirect("/");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [Authorize]
        [Authorize]
        public IActionResult Payment()
        {
            int userid = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            var order = _context.Orders
                .Include(o => o.OrderDetails)
                .FirstOrDefault(o => o.UserId == userid && !o.IsFinaly);
            if (order == null)
            {
                return NotFound();
            }

            var payment = new Payment((int)order.OrderDetails.Sum(d => d.Price));
            var res = payment.PaymentRequest($"پرداخت فاکتور شماره {order.OrderId}",
                "https://103.215.223.93/Home/OnlinePayment/" + order.OrderId, "khorsandmorteza013@gmail.com", "09361190125");
            if (res.Result.Status == 100)
            {
                return Redirect("https://sandbox.zarinpal.com/pg/StartPay/" + res.Result.Authority);
            }
            else
            {
                return BadRequest();
            }

        }

        public IActionResult OnlinePayment(int id)
        {
            if (HttpContext.Request.Query["Status"] != "" &&
                HttpContext.Request.Query["Status"].ToString().ToLower() == "ok" &&
                HttpContext.Request.Query["Authority"] != "")
            {
                string authority = HttpContext.Request.Query["Authority"].ToString();
                var order = _context.Orders.Include(o => o.OrderDetails)
                    .FirstOrDefault(o => o.OrderId == id);
                var payment = new Payment((int)order.OrderDetails.Sum(d => d.Price));
                var res = payment.Verification(authority).Result;
                if (res.Status == 100)
                {
                    order.IsFinaly = true;
                    _context.Orders.Update(order);
                    _context.SaveChanges();
                    ViewBag.code = res.RefId;
                    return View();
                }
            }

            return NotFound();

        }
        [HttpPost]
        public IActionResult SendEmail(EmailViewModel email)
        {
            _messageService.SendEmailAsync("info@namg.ir", "میخواهد سایت ما را دنبال کند",email.body);

            return Redirect("/");
        }

        public IActionResult Resume()
        {
            
            return View();
        }
    }
}
