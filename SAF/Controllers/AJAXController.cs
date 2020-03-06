using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using SAF.DAL;
using SAF.Extensions;
using SAF.Models;

namespace SAF.Controllers
{
    public class AJAXController : Controller
    {
        private readonly Db_Saf _context;
        private readonly AppSettings _appSettings;

        public AJAXController(Db_Saf context, IOptions<AppSettings> appSettings)
        {
                _context = context;
                _appSettings = appSettings.Value;
        }

        public async Task<IActionResult> SendSms(string header, string body, int[] doctors)
        {

            if(header == null || body == null || doctors == null)
            {
                return NotFound();
            }
            using var client = new System.Net.Http.HttpClient();

            var loginName = _appSettings.LoginName;


            foreach (var d in doctors)
            {
                var doctor = await _context.Doctors.FindAsync(d);

                var msisdn = doctor.MobileNumber;

                var senderName = _appSettings.SenderName;

                var msgBody = body;

                var hashInLogin = Md5Hash(_appSettings.Password) + loginName + msgBody + msisdn + senderName;
                var key = Md5Hash(hashInLogin);
                var forKey = "login=" + loginName + "&msisdn=" + msisdn + "&text=" + System.Web.HttpUtility.UrlEncode(msgBody) + "&sender=" + System.Web.HttpUtility.UrlEncode(senderName) + "&key=" + key;

                var requestUrl = new Uri(_appSettings.Url + forKey);
                var response = await client.GetAsync(requestUrl);
                var result = await response.Content.ReadAsStringAsync();


                var message = new SendSms()
                {
                    Subject = header,
                    Number = doctors.Length,
                    Date = DateTime.Now,
                    Status = true,
                    Text = body
                };

                await _context.Messages.AddAsync(message);

            }
         
            await _context.SaveChangesAsync();

            return Ok();
        }

        private static string Md5Hash(string input)
        {
            var hash = new StringBuilder();
            var md5Provider = new MD5CryptoServiceProvider();
            var bytes = md5Provider.ComputeHash(new UTF8Encoding().GetBytes(input));

            foreach (var t in bytes)
                hash.Append(t.ToString("x2"));

            return hash.ToString();
        }

        public IActionResult LoadMessages(int skip)
        {
            var model =
                _context.Messages.OrderByDescending(g => g.Id).Skip(skip).Take(12);

            return PartialView("_MessagesPartialView", model);
        }


        public IActionResult LoadSendSms(int skip)
        {
            var model =
                _context.Doctors.OrderByDescending(g => g.Id).Skip(skip).Take(12);

            return PartialView("_SendSmsPartialView", model);
        }

        public IActionResult LoadDoctors(int skip)
        {
            var model =
                _context.Doctors.OrderByDescending(g => g.Id).Skip(skip).Take(12);

            return PartialView("_DoctorsPartialView", model);
        }
        public IActionResult SearchDoctor(int skip, string name, string profession, string work, string region)
        {
            var model =
                _context.Doctors.OrderByDescending(g => g.Id).Where(p => p.FullName.Contains(name) ||
                                                                    p.Profession.Contains(profession) ||
                                                                    p.WorkPlace.Contains(work) ||
                                                                    p.Region.Contains(region));

            ViewBag.Count = model.Count();

            return PartialView("_SendSmsPartialView", model.Skip(skip).Take(12));
        }
    }
}