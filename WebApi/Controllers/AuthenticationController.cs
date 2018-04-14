using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using DataLayer;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebApi.Auth;
using WebApi.Models;

namespace WebApi.Controllers
{
    public class AuthenticationController : Controller
    {
        ApplicationContext context = new ApplicationContext();
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;


        public AuthenticationController(
            UserManager<User> userManager,
            SignInManager<User> signInManager
            )
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public IActionResult Register()
        {
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }
       
        [HttpPost]
        public async Task<IActionResult> Login(UserModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(model.Username, model.Password, isPersistent: true, lockoutOnFailure: false);
                if (result.Succeeded)
                {
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, model.Username)
                    };
                    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));
                    return RedirectToAction("Index", "Task");
                }
                
            }

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(UserModel model)
        {

            var user = new User { UserName = model.Username};
            var result = await _userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                 var signinResult = await _signInManager.PasswordSignInAsync(model.Username, model.Password, isPersistent: true, lockoutOnFailure: false);
                if (signinResult.Succeeded) {

                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, model.Username)
                    };
                    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));
                    return RedirectToAction("Index", "Task");

                }

            }
            return View();
        }
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Authentication");
        }
    }
}