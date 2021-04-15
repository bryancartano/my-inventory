using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using EntprogFinalProject.Data;
using EntprogFinalProject.Models;

namespace EntprogFinalProject.Controllers
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

            return RedirectToAction("OrderIndex");
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
