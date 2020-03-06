using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;
using OfficeOpenXml.Style;
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

        public IActionResult ExcelExport() 
        {
            string[] col_names = new string[]
            {
                "Həkimin Adı/Soyadı",
                "Peşəsi",
                "İş yeri",
                "Bölgəsi",
                "Telefon Nömrəsi"
            };

            byte[] result;

            using(var package = new ExcelPackage())
            {
                var worksheet = package.Workbook.Worksheets.Add("Final");

                for(int i = 0; i < col_names.Length; i++)
                {
                    worksheet.Cells[1, i + 1].Style.Font.Size = 14;
                    worksheet.Cells[1, i + 1].Style.Font.Color.SetColor(Color.White);
                    worksheet.Cells[1, i + 1].Value = col_names[i];
                    worksheet.Cells[1, i + 1].Style.Font.Bold = true;
                    worksheet.Cells[1, i + 1].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    worksheet.Cells[1, i + 1].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    worksheet.Cells[1, i + 1].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(48,122,2));
                }

                int row = 2;

                foreach(var item in _context.Doctors.ToList())
                {
                    for(int col = 1; col <= 2; col++)
                    {
                        worksheet.Cells[row, col].Style.Font.Size = 12;
                        worksheet.Cells[row, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    }
                    worksheet.Cells[row, 1].Value = item.FullName;
                    worksheet.Cells[row, 2].Value = item.Profession;
                    worksheet.Cells[row, 3].Value = item.WorkPlace;
                    worksheet.Cells[row, 4].Value = item.Region;
                    worksheet.Cells[row, 5].Value = item.MobileNumber;

                    if (row % 2 == 0)
                    {
                        for (int i = 0; i < col_names.Length; i++)
                        {
                            worksheet.Cells[row, i + 1].Style.Fill.PatternType = ExcelFillStyle.Solid;
                            worksheet.Cells[row, i + 1].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(195, 255, 158));
                        }

                    }
                    row++;

                }
                worksheet.Cells[worksheet.Dimension.Address].AutoFitColumns();

                result = package.GetAsByteArray();
            }

            return File(result, "application/vnd.ms-excel", "doctors.xlsx");

        }

        public IActionResult Import(HttpPostedFileBase) 
        {

        }
    }
}