using Microsoft.AspNetCore.Mvc;
using Core_MVC_Project_6.Repositeries;
using Core_MVC_Project_6.Models;
using X.PagedList;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace Core_MVC_Project_6.Controllers
{
	[Authorize]
	public class CategoryController : Controller
	{
		CategoryRepositeries cRepo = new CategoryRepositeries();

		private readonly ILogger<CategoryController> _logger;

		public CategoryController(ILogger<CategoryController> logger)
		{
			_logger = logger;
		}

		public IActionResult Index(int page = 1)
		{
			var categories = cRepo.TList().ToPagedList(page, 3);
			return View(categories);
		}

		[HttpGet]
		public IActionResult AddCategory()
		{
			return View();
		}

		[HttpPost]
		public IActionResult AddCategory(Category c)
		{

            cRepo.AddT(c);
            return RedirectToAction("Index");
        }

		public IActionResult DeleteCategory(int id)
		{
			var category = cRepo.GetT(id);
			cRepo.DeleteT(category);

			return RedirectToAction("Index");
		}

		[HttpGet]
        public IActionResult UpdateCategory(int id)
        {
			var category = cRepo.GetT(id);

			return View(category);
        }

        [HttpPost]
		public IActionResult UpdateCategory(Category c)
		{
			cRepo.UpdateT(c);
			return RedirectToAction("Index");
		}

		public IActionResult ActivationCategory(int id)
		{
			var category = cRepo.GetT(id);
			if(category.Status)
			{
				category.Status = false;
            }

			else
			{
				category.Status = true;
			}
			cRepo.UpdateT(category);
			return RedirectToAction("Index");
		}

		public async Task<IActionResult> LogOut()
		{
			await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

			return RedirectToAction("Index", "Login");
		}

	}
}
