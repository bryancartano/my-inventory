using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using FinalProject.Data;
using FinalProject.Models;

namespace FinalProject.Controllers
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
        public IActionResult OrderForm(Order forms)
        {
            var form = new Order()
            {
                Firstname = forms.Firstname,
                Lastname = forms.Lastname,
                Email = forms.Email,
                Address = forms.Address,
                PhoneNumber = forms.PhoneNumber,
                Service = forms.Service
            };

            _context.Orders.Add(form);
            _context.SaveChanges();



            return RedirectToAction("OrderIndex");
        }
    }
}
