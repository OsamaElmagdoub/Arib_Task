using Arib_Task.Models;
using Arib_Task.ViewModels.AccountViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Arib_Task.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AccountController(UserManager<ApplicationUser> userManager
            , SignInManager<ApplicationUser> signInManager
            )
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        

        

        //get : login 
        [HttpGet]

        public IActionResult Login()
        {
            return View();
        }

        // Post : Login
        [HttpPost]

        public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(loginViewModel);
            }


            var user = await _userManager.Users
                .FirstOrDefaultAsync(u => u.Email == loginViewModel.UserName
                || u.PhoneNumber == loginViewModel.UserName);



            if (user == null)
            {
                ModelState.AddModelError(string.Empty, " هذا المستخدم غير موجود.");
                return View(loginViewModel);
            }



            var result = await _signInManager.PasswordSignInAsync
                (user, loginViewModel.Password, loginViewModel.RememberMe, false);

            if (result.Succeeded)
            {


                if (await _userManager.IsInRoleAsync(user, "Admin"))
                    return RedirectToAction("Index", "Dashboard", new { area = "Admin" });
                else
                {
                    return RedirectToAction("Index", "Home"); // للمستخدم العادي

                }

            }
            ModelState.AddModelError("", "بيانات الدخول غير صحيحه ");

            return View(loginViewModel);

        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login");
        }

        

        

    }
}
