using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Core_MVC_Project_6.Models;

namespace Core_MVC_Project_6.Controllers
{
    public class LoginController : Controller
    {
        Context c = new Context();
        
        [HttpGet]
        public IActionResult Index()
        {
            ClaimsPrincipal claimUser = HttpContext.User;

            if(claimUser.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Category");
            }


			return View();
        }

        
       
        public async Task<IActionResult> Index(Admin admin)
        {
            var data = c.Admins.FirstOrDefault(m => m.AdminName == admin.AdminName && m.Password == admin.Password);

            if(data != null)
            {
                List<Claim> claims = new List<Claim>()
                {
                    new Claim(ClaimTypes.NameIdentifier,admin.AdminName),
                    new Claim("OtherProperties","Example Role")
                };

                ClaimsIdentity identity = new ClaimsIdentity(claims,CookieAuthenticationDefaults.AuthenticationScheme);

                AuthenticationProperties properties = new AuthenticationProperties()
                {
                    AllowRefresh = true,
                    IsPersistent = admin.KeepLoggedIn
				};

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(identity), properties);

                return RedirectToAction("Index","Category");
            }

            ViewData["ValidateMessage"] = "User not found !";
            return View();
        }


		[HttpPost]
		public async Task<IActionResult> Index2(Admin admin)
		{
			var data = c.Admins.FirstOrDefault(m => m.AdminName == admin.AdminName && m.Password == admin.Password);

			if (data != null)
			{
				List<Claim> claims = new List<Claim>()
				{
					new Claim(ClaimTypes.NameIdentifier,admin.AdminName),
					new Claim("OtherProperties","Example Role")
				};

				ClaimsIdentity identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

				AuthenticationProperties properties = new AuthenticationProperties()
				{
					AllowRefresh = true,
					IsPersistent = admin.KeepLoggedIn
				};

				await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(identity), properties);

				return RedirectToAction("Index", "Category");
			}

			ViewData["ValidateMessage"] = "User not found !";
			return View();
		}

	}
}
