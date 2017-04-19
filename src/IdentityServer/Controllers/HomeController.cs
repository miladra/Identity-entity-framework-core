using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using IdentityEF.Models.Identity;
using Microsoft.AspNetCore.Authorization;

namespace IdentityEF.Controllers
{
    public class HomeController : Controller
    {

        private readonly UserManager<ApplicationUser> userManager;

        public HomeController(UserManager<ApplicationUser> userManager)
        {
            this.userManager = userManager;
        }


       [Authorize]
        public IActionResult Index()
        {
            ApplicationUser user = userManager.GetUserAsync(HttpContext.User).Result;

            ViewBag.Message = $"Welcome {user.FullName}!";
            if (userManager.IsInRoleAsync(user, "NormalUser").Result)
            {
                ViewBag.RoleMessage = "You are a NormalUser.";
            }
            return View();
        }
        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
