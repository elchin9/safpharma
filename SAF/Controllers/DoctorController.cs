using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SAF.DAL;
using SAF.Models;

namespace SAF.Controllers
{
    public class DoctorController : Controller
    {
        private readonly Db_Saf _context;

        public DoctorController(Db_Saf context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            ViewBag.Active = "Doctors";
            ViewBag.Count = _context.Doctors.Count();
            return View(_context.Doctors.OrderByDescending(p => p.Id).Take(12));
        }

        public PartialViewResult Create()
        {
            return PartialView("_CreateDoctorPartialView");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Doctor doctor)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account");
            }

            if (!User.IsInRole("Admin"))
            {
                return RedirectToAction("Login", "Account");
            }
            if (!ModelState.IsValid)
            {
                ViewBag.Active = "Doctors";

                return View(doctor);
            }

            await _context.Doctors.AddAsync(doctor);
           
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<PartialViewResult> Update(int id)
        {
            var model = await _context.Doctors.FindAsync(id);

            return PartialView("_UpdateDoctorPartialView", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(Doctor doctor)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account");
            }

            if (!User.IsInRole("Admin"))
            {
                return RedirectToAction("Login", "Account");
            }
            if (!ModelState.IsValid)
            {
                ViewBag.Active = "Doctors";

                return View(doctor);
            }

            var currentDoctor = await _context.Doctors.FindAsync(doctor.Id);

            currentDoctor.FullName = doctor.FullName;
            currentDoctor.Profession = doctor.Profession;
            currentDoctor.WorkPlace = doctor.WorkPlace;
            currentDoctor.Region = doctor.Region;
            currentDoctor.MobileNumber = doctor.MobileNumber;

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> DeleteDoctor(int id)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account");
            }

            if (!User.IsInRole("Admin"))
            {
                return RedirectToAction("Login", "Account");
            }
            if (!ModelState.IsValid)
            {
                ViewBag.Active = "Doctors";
            }

            var model = _context.Doctors.FirstOrDefault(p => p.Id == id);

            _context.Doctors.Remove(model);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}