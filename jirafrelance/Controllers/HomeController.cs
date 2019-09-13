using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using jirafrelance.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Logging;

namespace jirafrelance.Controllers
{
    public class HomeController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IEmailSender _emailSender;
        private readonly RoleManager<IdentityRole> roleManagers;
        private readonly JiraContext _context;

        public HomeController(UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            RoleManager<IdentityRole> roleManager,
            JiraContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            roleManagers = roleManager;
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            #region create other default roles
            if (await roleManagers.RoleExistsAsync("Admin") == false)
            {
                IdentityResult Teacher = await roleManagers
                     .CreateAsync(new IdentityRole
                     {
                         Name = "Admin",
                     });
            }

            if (await roleManagers.RoleExistsAsync("Employer") == false)
            {
                IdentityResult Employer = await roleManagers
                 .CreateAsync(new IdentityRole
                 {
                     Name = "Employer",
                 });
            }

            if (await roleManagers.RoleExistsAsync("Freelancer") == false)
            {

                IdentityResult Freelancer = await roleManagers
                 .CreateAsync(new IdentityRole
                 {
                     Name = "Freelancer",
                 });
            }
            if (await roleManagers.RoleExistsAsync("Support") == false)
            {

                IdentityResult Support = await roleManagers
                 .CreateAsync(new IdentityRole
                 {
                     Name = "Support",
                 });
            }
            #endregion
            //ViewBag.Roles = roleManagers.Roles;
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
