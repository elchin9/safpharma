using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SAF.DAL;
using SAF.Models;
using SAF.ViewModel;

namespace SAF.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly Db_Saf _context;

        public HomeController(ILogger<HomeController> logger, Db_Saf context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account");
            }

            if (!User.IsInRole("Admin"))
            {
                return RedirectToAction("Login", "Account");
            }

            var viewModel = new HomeViewModel()
            {
                Doctors = _context.Doctors.OrderByDescending(p => p.Id).Take(4),
                Messages = _context.Messages.OrderByDescending(p => p.Id).Take(4)
            };

            ViewBag.Active = "Home";

            return View(viewModel);
        }

        public IActionResult Send()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account");
            }

            if (!User.IsInRole("Admin"))
            {
                return RedirectToAction("Login", "Account");
            }
            ViewBag.Active = "Send";
            ViewBag.Count = _context.Messages.Count();
            return View(_context.Messages.OrderByDescending(p => p.Id).Take(12));
        }
    }
}
