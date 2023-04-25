using Core_MVC_Project_6.Repositeries;
using Microsoft.AspNetCore.Mvc;

namespace Core_MVC_Project_6.ViewComponents
{
	public class FoodGetList : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			FoodRepositeries fRepo = new FoodRepositeries();

			var foodList = fRepo.TList();

			return View(foodList);
		}
	}
}
