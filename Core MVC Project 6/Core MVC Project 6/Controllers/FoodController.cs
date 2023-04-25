using Microsoft.AspNetCore.Mvc;
using Core_MVC_Project_6.Repositeries;
using Core_MVC_Project_6.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using X.PagedList;
using Microsoft.AspNetCore.Authorization;

namespace Core_MVC_Project_6.Controllers
{
	[Authorize]
	public class FoodController : Controller
	{
        FoodRepositeries fRepo = new FoodRepositeries();
		CategoryRepositeries cRepo = new CategoryRepositeries();
        public IActionResult Index(int page = 1)
		{
			var foods = fRepo.TList("Category").ToPagedList(page, 3);
			return View(foods);
		}

		public IActionResult DeleteFood(int id)
		{
			var food = fRepo.GetT(id);
			fRepo.DeleteT(food);

			return RedirectToAction("Index");
		}

		[HttpGet]
		public IActionResult UpdateFood(int id)
		{
			var food = fRepo.GetT(id);
            List<SelectListItem> FoodsCategories = (from x in cRepo.TList()
                                                    select new SelectListItem
                                                    {
                                                        Text = x.CategoryName,
                                                        Value = x.CategoryID.ToString()
                                                    }).ToList();

            ViewBag.foodsCategories = FoodsCategories;
            return View(food);
		}

		[HttpPost]
		public IActionResult UpdateFood(Food f) 
		{
			fRepo.UpdateT(f);
			return RedirectToAction("Index");
		}

		[HttpGet]
		public IActionResult AddFood()
		{
			List<SelectListItem> FoodsCategories = (from x in cRepo.TList()
													select new SelectListItem
													{
														Text = x.CategoryName,
														Value = x.CategoryID.ToString()
													}).ToList();

			ViewBag.foodsCategories = FoodsCategories;

			return View();
		}

		[HttpPost]
		public IActionResult AddFood(Food f)
		{
			fRepo.AddT(f);

			return RedirectToAction("Index");
		}

		public IActionResult ActivationFood(int id)
		{
			var food = fRepo.GetT(id);
			if(food.Status)
			{
				food.Status = false;
			}

			else
			{
				food.Status = true;
			}
			fRepo.UpdateT(food);
			return RedirectToAction("Index");
		}

	}
}
