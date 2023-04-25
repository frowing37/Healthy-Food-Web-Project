using Microsoft.AspNetCore.Mvc;
using Core_MVC_Project_6.Repositeries;

namespace Core_MVC_Project_6.ViewComponents
{
	public class FoodListbyCategory : ViewComponent
	{
		public IViewComponentResult Invoke(int? id)
		{
			FoodRepositeries fRepo = new FoodRepositeries();

			var foodList = fRepo.T2List(m => m.CategoryID == id);

			return View(foodList);
		}
	}
}

