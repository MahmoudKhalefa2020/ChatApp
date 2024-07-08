using ImoApp.Models;
using ImoApp.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SignInResult = Microsoft.AspNetCore.Identity.SignInResult;

namespace ImoApp.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;

        public AccountController(UserManager<ApplicationUser> _usermanager, SignInManager<ApplicationUser> _signInManager)
        {
            userManager = _usermanager;
            signInManager = _signInManager;
        }

        public IActionResult Registration()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Registration(UserRegister userRegister)

        {

            if (ModelState.IsValid)
            {
                ApplicationUser user = new ApplicationUser();

                user.UserName = userRegister.Name;
                user.PhoneNumber = userRegister.PhoneNumber;
                user.PhoneNumberConfirmed = userRegister.PhoneNumberConfirmed;
                user.PasswordHash = userRegister.Password;
                user.PasswordConfirmed = userRegister.PsswordConfirmed;
                IdentityResult result = await userManager.CreateAsync(user, userRegister.Password);
                if (result.Succeeded)
                {
                    await signInManager.SignInAsync(user, false);
                    return RedirectToAction(nameof(Login));


                }

                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }

            }

            return View(userRegister);


        }

        public IActionResult Login()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Login(UserLogin userLogin)

        {
            if (ModelState.IsValid)
            {
                ApplicationUser applicationUser = await userManager.FindByNameAsync(userLogin.UserName);

                if (applicationUser != null)
                {
                    SignInResult Result = await signInManager.PasswordSignInAsync(applicationUser, userLogin.Password, userLogin.RememberMe, false);
                    if (Result.Succeeded)
                    {
                        return RedirectToAction("Index", "User");
                    }
                }

                else
                {
                    ModelState.AddModelError("", "WrongData");
                }

            }
            return View(userLogin);

        }


        public IActionResult Logout()
        {
            signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
