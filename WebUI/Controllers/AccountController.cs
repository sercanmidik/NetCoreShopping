using DtoLayer.AccountDtos;
using EntityLayer.Entity;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers
{
    [AllowAnonymous]
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

		public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
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
        public async Task<IActionResult> CreateRegister(CreateAccountDto createAccount)
        {
            if(ModelState.IsValid)
            {
                AppUser user = new AppUser()
                {
                    Email= createAccount.Email,
                    UserName= createAccount.UserName,
                    Name= createAccount.Name,
                    SurName= createAccount.SurName,
                    ImageUrl= "review-1.png"
				};
                var result= await _userManager.CreateAsync(user,createAccount.Password);
                if(result.Succeeded)
                {
                    return RedirectToAction("Login", "Account");
                }
            }
            return View();
        }
		[HttpPost]
		public async Task<IActionResult> Login(LoginDto loginDto)
		{
            if(ModelState.IsValid)
            {
				var result = await _signInManager.PasswordSignInAsync(loginDto.UserName, loginDto.Password, false, false);
				if (result.Succeeded)
				{
					return RedirectToAction("Index", "Default");
				}
			}
			
			return View();
		}

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();

            // İsteğe bağlı olarak, başka bir sayfaya yönlendirebilirsiniz.
            return RedirectToAction("Index", "Default");
        }
    }
}
