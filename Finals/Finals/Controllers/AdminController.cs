using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using Finals.Data;
using Finals.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;



namespace Finals.Controllers
{
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _context;
        public AdminController(ApplicationDbContext context)
        {
            _context = context;
        }
        [Authorize]
        public IActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        public IActionResult Admin()
        {
            return View();
        }
        [AllowAnonymous, HttpPost]
        public IActionResult Admin(Admin admin)
        {
            if (ModelState.IsValid)
            {
                if (admin.Username == "AngryNerds" && admin.Password == "AngryNerds")
                {
                    var claims = new[] { new Claim("name", admin.Username), new Claim(ClaimTypes.Role, "Admin") };
                    var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                    return Redirect("~/Order/OrderIndex");
                }
                else
                {
                    ModelState.AddModelError("", "Login failed. Please check Username and/or password");
                }
            }

            return View();
        }
     
    }
}
 