using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SpeakerFreak.Models;
using Microsoft.AspNetCore.Identity;
using SpeakerFreak.ViewModels;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace SpeakerFreak.Controllers
{
    public class AccountController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
    
        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager,ApplicationDbContext db)
        {

            _userManager = userManager;
            _signInManager = signInManager;
            _db = db;   
        }


        public IActionResult Index()
        {
            return View();
        }


        //Creat Register View
        public IActionResult Register()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {

            var user = new ApplicationUser { UserName = model.Email };
            IdentityResult result = await _userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                return RedirectToAction("Index");
            } // still have to create error page once models are made will do that.
            else
            {
                return View();
            }
        }


        public IActionResult Login()
        {
            return View();
        }

        
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel user)
        {
            //LoginView Model
            // SigninAsync is to allow user to sign who have already registred.
            // True (isPresistent) keeps user logged even if they have not logged off. e.g email keeps password unless manually user logs out
            Microsoft.AspNetCore.Identity.SignInResult result = await _signInManager.PasswordSignInAsync(user.Email, user.Password, isPersistent: true, lockoutOnFailure: false);

            if (result.Succeeded)
            {
                return RedirectToAction("Index","Account");
            }
            else
            {
                return View();
            }
        }


        // No need to have a its own view page.
        [HttpPost]       
        public async Task<IActionResult> LogOff()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index");
        }
    }
}

