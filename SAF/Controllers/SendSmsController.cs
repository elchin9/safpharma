using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SAF.DAL;

namespace SAF.Controllers
{
    public class SendSmsController : Controller
    {
        private readonly Db_Saf _context;

        public SendSmsController(Db_Saf context)
        {
            _context = context; 
        }
        public IActionResult Index()
        {
            ViewBag.Active = "SendSms";
            //ViewBag.Professions = _context.Doctors.GroupBy(p => p.Profession);
            ViewBag.Count = _context.Doctors.Count();
            return View(_context.Doctors.OrderByDescending(p => p.Id).Take(12));
        }
    }
}