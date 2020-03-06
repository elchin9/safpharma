using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SAF.DAL;
using SAF.Models;
using SAF.ViewModel;

namespace SAF.Controllers
{
    public class AccountController : Controller
    {
        private readonly Db_Saf _context;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;

        public AccountController(Db_Saf context, SignInManager<AppUser> signInManager, UserManager<AppUser> userManager)
        {
            _context = context;
            _signInManager = signInManager;
            _userManager = userManager;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel LoginViewModel)
        {
            if (!ModelState.IsValid) return View(LoginViewModel);

            AppUser user = await _userManager.FindByEmailAsync(LoginViewModel.Email);

            if (user == null)
            {
                ModelState.AddModelError("", "Email və ya şifrə səhvdir.");
                return View(LoginViewModel);
            }

            Microsoft.AspNetCore.Identity.SignInResult signInResult =
                 await _signInManager.PasswordSignInAsync(user, LoginViewModel.Password, LoginViewModel.RememberMe, true);

            if (!signInResult.Succeeded)
            {
                ModelState.AddModelError("", "Email və ya şifrə səhvdir.");
                return View(LoginViewModel);
            }

            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();

            return RedirectToAction("Login", "Account");
        }
    }
}