using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using Finals.Data;
using Finals.Models;

using System.Net;
using System.Net.Mail;

namespace Finals.Controllers
{
    public class OrderController : Controller
    {
     
            private readonly ApplicationDbContext _context;
            public OrderController(ApplicationDbContext context)
            {
                _context = context;
            }
            public IActionResult OrderIndex()
            {
                var orderlist = _context.Orders.Include(p => p.Service).ToList();
                return View(orderlist);
            }
            public IActionResult OrderForm()
            {
                return View();
            }
            [HttpPost]
            public IActionResult OrderForm(OrderViewModel forms)
            {
                using (MailMessage mail = new MailMessage("bryancarlo136@gmail.com", forms.Email))
                {

                    string message = "Hello, " + forms.Lastname + "!<br/><br/>" +
                        "We have received your inquiry. Here are the details: <br/><br/>" +
                        "Contact Number: <strong>" + forms.PhoneNumber + "</strong><br/>" +
                        "Message:<br/> </strong><br/><br/>" +
                        "Please wait for our reply. Thank you!";
                    mail.Body = message;
                    mail.IsBodyHtml = true;

                    using (SmtpClient smtp = new SmtpClient())
                    {
                        smtp.Host = "smtp.gmail.com";
                        smtp.EnableSsl = true;
                        NetworkCredential NetworkCred =
                            new NetworkCredential("bryancarlo136@gmail.com", "bryancarts24");
                        smtp.UseDefaultCredentials = false;
                        smtp.Credentials = NetworkCred;
                        smtp.Port = 587;
                        smtp.Send(mail);
                        ViewBag.Message = "Inquiry sent.";
                    }
                }

                var service = _context.Services.Where(s => s.SerKey == forms.SerKey).SingleOrDefault();

                var form = new Order()
                {
                    Firstname = forms.Firstname,
                    Lastname = forms.Lastname,
                    Email = forms.Email,
                    Address = forms.Address,
                    PhoneNumber = forms.PhoneNumber,
                    Service = service
                };

                _context.Orders.Add(form);
                _context.SaveChanges();

                return RedirectToAction("Index", "Home");
            }

            public IActionResult EditForm(int? id)
            {
                if (id == null)
                {
                    return RedirectToAction("OrderIndex");
                }
                var form = _context.Orders.Where(o => o.OrderKey == id).SingleOrDefault();
                if (form == null)
                {
                    return RedirectToAction("Index");
                }
                return View(form);
            }

            [HttpPost]
            public IActionResult EditForm(int? id, Order forms)
            {
                var form = _context.Orders.Where(o => o.OrderKey == id).SingleOrDefault();
                form.Firstname = forms.Firstname;
                form.Lastname = forms.Lastname;
                form.Email = forms.Email;
                form.Address = forms.Address;
                form.PhoneNumber = forms.PhoneNumber;
                form.Service = forms.Service;

                _context.Orders.Update(form);
                _context.SaveChanges();

                return RedirectToAction("OrderIndex");
            }
            public IActionResult DeleteForm(int? id)
            {
                if (id == null)
                {
                    return RedirectToAction("OrderIndex");
                }
                var form = _context.Orders.Where(o => o.OrderKey == id).SingleOrDefault();
                if (form == null)
                {
                    return RedirectToAction("OrderIndex");
                }
                _context.Orders.Remove(form);
                _context.SaveChanges();

                return RedirectToAction("OrderIndex");
            }
        
    }
}
