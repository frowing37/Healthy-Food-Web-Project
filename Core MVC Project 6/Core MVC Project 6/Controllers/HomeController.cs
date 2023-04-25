using Microsoft.AspNetCore.Mvc;

namespace Core_MVC_Project_6.Controllers
{
	public class HomeController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}

		public IActionResult GetCategoryDetails(int id)
		{
			ViewBag.ID = id;

			return View();
		}
	}
}
