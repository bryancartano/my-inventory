using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using FinalProject.Data;
using FinalProject.Models;

namespace FinalProject.Controllers
{
    public class OrderController : Controller
    {
        public IActionResult Order()
        {
            return View();
        }

    }
}
